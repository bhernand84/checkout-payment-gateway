using Checkout.Payment.Api.Data;
using Checkout.Payment.Api.Data.Models;
using Checkout.Payment.Api.Services;
using Checkout.Payment.Api.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PaymentContext>(options => options.UseInMemoryDatabase(databaseName: "checkoutPayment"));
builder.Services.AddScoped<IPaymentService, BankPaymentService>();
builder.Services.AddScoped<IBankSettings, BankSettings>();
builder.Services.AddScoped<IPaymentDataService, PaymentDataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();