using CRM.Application.Interface;
using CRM.Application.Main;
using CRM.Domain.Interface;
using CRM.Domain.Core;
using CRM.Infrastructure.Interface;
using CRM.Infrastructure.Repository;
using CRM.Infrastructure.Data;
using CRM.Transversal.Common;
using CRM.Transversal.Logging;
using CRM.Transversal.Mapping;
using CRM.Service.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);
var appSettings = new AppSettings();
builder.Configuration.GetSection("Configurations").Bind(appSettings);

// Add services to the container.

#region services
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Configurations"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFactoryConnection, FactoryConnection>();
builder.Services.AddScoped<ICustomerApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomerDomain>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = appSettings.Issuer,
    ValidAudience = appSettings.Audience,
    IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(appSettings.Secret ?? string.Empty)
    )
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
