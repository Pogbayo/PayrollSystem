using MediatR;
using Payroll.Application.Common;

public record ProcessPaymentCommand(int Month, int Year)
    : IRequest<ApiResponse<string>>;
