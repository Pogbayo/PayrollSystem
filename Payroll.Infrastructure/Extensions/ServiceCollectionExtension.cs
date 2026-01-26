using Amazon.SimpleEmail;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Payroll.Application.Common;
using Payroll.Application.Interfaces.IRepository;
using Payroll.Application.Interfaces.IService;
using Payroll.Application.Interfaces.Services;
using Payroll.Application.Services;
using Payroll.Infrastructure.Data;
using Payroll.Infrastructure.Notifications;
using Payroll.Infrastructure.Repositories;

namespace Payroll.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CompanySettings>(configuration.GetSection("Company"));
            services.Configure<AwsSettings>(configuration.GetSection("AWS"));

            services.AddDbContext<PayrollDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.CommandTimeout(60)));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPayrollEntryRepository, PayrollEntryRepository>();
            services.AddScoped<IPayrollRunRepository, PayrollRunRepository>();
            services.AddScoped<IPayslipRepository, PayslipRepository>();
            services.AddScoped<ISalaryStructureRepository, SalaryStructureRepository>();

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPayrollProcessingService, PayrollProcessingService>();
            services.AddScoped<ISimpleEmailService, SimpleEmailService>();

            services.AddScoped<IAmazonSimpleEmailService>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<AwsSettings>>().Value;
                return new AmazonSimpleEmailServiceClient(
                    settings.AccessKeyId,
                    settings.SecretAccessKey,
                    Amazon.RegionEndpoint.GetBySystemName(settings.Region)
                );
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
