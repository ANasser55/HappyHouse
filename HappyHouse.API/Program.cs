using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using HappyHouse;
using System.Text;
using HappyHouse.Application.Interfaces;
using HappyHouse.Application.Services;
//using HappyHouse.Application;
using HappyHouse.Infrastructure;
using HappyHouse.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
// Add this temporary code for debugging
var testJwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();


var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });

builder.Services.AddInfrastructure(builder.Configuration);


//builder.Services.AddDbContext<HappyHouseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<ICustomerRegistrationService, CustomerRegistrationService>();
builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddScoped<IInstallmentsService, InstallmentsService>();
builder.Services.AddScoped<ILedgerService, LedgerService>();
builder.Services.AddScoped<HappyHouse.Application.Interfaces.IAuthenticationService, HappyHouse.Application.Services.AuthenticationService>();





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
