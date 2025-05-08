using ParkingUZ.API;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess;
using ParkingUZ.Application;
using ParkingUZ.Application.Helpers;
using Telegram.Bot;
using ParkingUZ.API.WebHookService;
using ParkingUZ.API.BotModels;
using MediaBrowser.Model.Services;
using ParkingUZ.Application.Services.Implement;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddControllers()
    .AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHostedService<ConfigureWebHook>();

builder.Services.AddHttpClient("tgwebhook")
    .AddTypedClient<ITelegramBotClient>(httpClient =>
    {
        var configuration = builder.Configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        return new TelegramBotClient(configuration.Token, httpClient);
    });

builder.Services.AddApplication(builder.Environment, builder.Configuration)
                .AddDataAccess(builder.Configuration);

builder.Services.AddAuth(builder.Configuration);
//builder.Services.AddSwagger();

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

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();

// Apply CORS middleware before authentication
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();