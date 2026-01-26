using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Payroll.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            var validatorAssembly = Assembly.GetExecutingAssembly();
            services.Scan(scan => scan
                .FromAssemblies(validatorAssembly)
                .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            //services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<IPayrollProcessingService, PayrollProcessingService>();

            return services;
        }
    }
}
