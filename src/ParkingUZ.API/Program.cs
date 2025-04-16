using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ParkingUZ.API;
using ParkingUZ.API.Filters;
using ParkingUZ.API.Middleware;
using ParkingUZ.DataAccess.Persistence;
using System.Text;
using ParkingUZ.Shared.Services.Impl;
using ParkingUZ.Shared.Services;
using ParkingUZ.DataAccess;
using ParkingUZ.Application;
using Microsoft.Extensions.Options;
using ParkingUZ.Application.Helpers.GenerateJwt;
using ParkingUZ.Application.Helpers;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddApplication(builder.Environment, builder.Configuration)
                .AddDataAccess(builder.Configuration);

builder.Services.AddAuth(builder.Configuration);
builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()//WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();

await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Apply CORS middleware before authentication
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//namespace ParkingUZ.API
//{
//    public partial class Program { }
//}
