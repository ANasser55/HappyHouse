using HappyHouse_Server.Controllers;
using HappyHouse_Server.Data;
using HappyHouse_Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HappyHouseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddScoped<CustomersService>();
builder.Services.AddScoped<CustomerRegistrationService>();
builder.Services.AddScoped<TransactionsService>();
builder.Services.AddScoped<InstallmentsService>();
builder.Services.AddScoped<LedgerService>();
builder.Services.AddScoped<MonthInstallmentsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
