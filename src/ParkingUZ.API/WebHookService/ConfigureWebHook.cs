
using ParkingUZ.API.BotModels;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ParkingUZ.API.WebHookService
{
    public class ConfigureWebHook : IHostedService
    {
        private readonly ILogger<ConfigureWebHook> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly BotConfiguration _botConfig;

        public ConfigureWebHook(ILogger<ConfigureWebHook> logger, 
            IServiceProvider serviceProvider, 
            IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _botConfig = configuration.GetSection("BotConfiguration").Get<BotConfiguration>()!;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            var webhookAddress = $@"{_botConfig.HostAddress}/bot/{_botConfig.Token}";

            _logger.LogInformation("Setting webhook");

            await botClient.SendMessage(
                chatId: 694317856,
                text: "Webhook o'rnatilmoqda");

            await botClient.SetWebhook(
                url: webhookAddress,
                allowedUpdates: Array.Empty<UpdateType>(),
                cancellationToken: cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            _logger.LogInformation("Webhook removing");

            await botClient.SendMessage(
                chatId: 694317856,
                text: "Bot uxlamoqda");
        }
    }
}
