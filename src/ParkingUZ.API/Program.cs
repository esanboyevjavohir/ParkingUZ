using Airways.DataAccess.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ParkingUZ.API;
using ParkingUZ.API.Filters;
using ParkingUZ.API.Middleware;
using ParkingUZ.DataAccess.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Parking API", Version = "v1" });
});
builder.Services.AddSwagger();

/*builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);*/

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
        policy.RequireRole("Role", "User"));

    options.AddPolicy("Admin", policy =>
        policy.RequireRole("Role", "Admin"));
});

var jwtOption = builder.Configuration.GetSection("JwtOptions").Get<JwtOption>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOption!.Issuer,
        ValidAudience = jwtOption.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOption.SecretKey))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<DataBaseContext>();

await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParkingUZ"); });

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlerMiddlewear>();
app.UseMiddleware<RabbitMqMiddleware>();

app.MapControllers();

app.Run();

namespace ParkingUZ.API
{
    public partial class Program { }
}
