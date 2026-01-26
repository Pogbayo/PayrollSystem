using Amazon.SimpleEmail;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Payroll.Application.Common;
using Payroll.Application.Extensions;
using Payroll.Application.Interfaces.IService;
using Payroll.Infrastructure.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.Run();

