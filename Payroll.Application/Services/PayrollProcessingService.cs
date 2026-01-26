using Microsoft.Extensions.Options;
using Payroll.Application.Common;
using Payroll.Application.Interfaces.IRepository;
using Payroll.Application.Interfaces.IService;
using Payroll.Domain.Enums;

namespace Payroll.Application.Services
{
    public class PayrollProcessingService : IPayrollProcessingService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IPayrollRunRepository _payrollRunRepo;
        private readonly IPaymentService _paymentService;
        private readonly CompanySettings _settings;

        private const int MaxRetryCount = 3;
        private const int RetryDelayMilliseconds = 500;

        public PayrollProcessingService(
            IEmployeeRepository employeeRepo,
            IPayrollRunRepository payrollRunRepo,
            IPaymentService paymentService,
            IOptions<CompanySettings> options)
        {
            _employeeRepo = employeeRepo;
            _payrollRunRepo = payrollRunRepo;
            _paymentService = paymentService;
            _settings = options.Value;
        }

        public async Task ProcessPayrollAsync(int month, int year)
        {
            var employees = await _employeeRepo.GetAllAsync();

            var payrollRun = CreatePayrollRun(month, year);
            payrollRun.Status = Status.Processing;

            foreach (var employee in employees)
            {
                var entry = CreatePayrollEntry(employee);

                var paid = await ProcessPaymentAsync(employee);

                entry.Status = paid
                    ? PayrollEntryStatus.Paid
                    : PayrollEntryStatus.Failed;

                if (!paid)
                {
                    payrollRun.Status = Status.PartiallyCompleted;
                }

                payrollRun.PayrollEntries.Add(entry);
            }

            payrollRun.Status = payrollRun.Status == Status.Processing
                ? Status.Completed
                : payrollRun.Status;

            await _payrollRunRepo.AddAsync(payrollRun);
        }


        private PayrollRun CreatePayrollRun(int month, int year)
        {
            return new PayrollRun
            {
                Month = month,
                Year = year,
                ProcessedAt = DateTime.UtcNow,
                Status = Status.Pending,
                PayrollEntries = new List<PayrollEntry>()
            };
        }

        private PayrollEntry CreatePayrollEntry(Employee employee)
        {
            return new PayrollEntry
            {
                EmployeeId = employee.Id,
                GrossPay = employee.BaseSalary,
                CreatedAt = DateTime.UtcNow,
                Status = PayrollEntryStatus.Pending
            };
        }

        private async Task<bool> ProcessPaymentAsync(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.BankAccountNumber))
                return false;

            for (int attempt = 1; attempt <= MaxRetryCount; attempt++)
            {
                var success = await _paymentService.PayAsync(employee.BankAccountNumber, employee.BaseSalary);

                if (success)
                    return true;

                if (attempt < MaxRetryCount)
                {
                    await Task.Delay(RetryDelayMilliseconds);
                }
            }

            return false;
        }
    }
}
