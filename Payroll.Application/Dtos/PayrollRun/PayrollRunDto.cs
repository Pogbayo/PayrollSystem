using Payroll.Application.Dtos.PayrollEntry;
using Payroll.Domain.Enums;
namespace Payroll.Application.Dtos.PayrollRun
{
    public class PayrollRunDto
    {
        public Guid Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Status Status { get; set; }
        public DateTime ProcessedAt { get; set; }
        public ICollection<PayrollEntryDto> PayrollEntries { get; set; } = new List<PayrollEntryDto>();
    }
}
