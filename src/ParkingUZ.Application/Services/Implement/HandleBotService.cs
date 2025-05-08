using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ParkingUZ.Application.Services.Implement
{
    public class HandleBotService
    {
        private readonly ILogger<HandleBotService> _logger;
        private readonly ITelegramBotClient _botClient;

        public HandleBotService(ILogger<HandleBotService> logger, ITelegramBotClient botClient)
        {
            _logger = logger;
            _botClient = botClient;
        }

        public async Task EchoAsync(Update update)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageRecieved(update.Message!),
                UpdateType.CallbackQuery => BotOnCallBackQueryRecieved(update.CallbackQuery!),
                _ => UnknownUpdadeTypeHandler(update)
            };

            try
            {
                await handler;
            }
            catch(Exception ex)
            {
                await HandlerErrorAsync(ex);
            }
        }

        private Task HandlerErrorAsync(Exception ex)
        {
            var ErrorMessage = ex switch
            {
                ApiRequestException apiRequestException => $"Telegram Api Error:\n" +
                    $"{apiRequestException.ErrorCode}",
                _ => ex.Message.ToString()
            };

            _logger.LogInformation(ErrorMessage);

            return Task.CompletedTask;
        }

        private async Task BotOnMessageRecieved(Message message)
        {
            _logger.LogInformation($"Message keldi : {message.Type}");

            await _botClient.SendMessage(
                chatId: message.Chat.Id,
                text: "Botga xabar keldi");
        }

        private async Task BotOnCallBackQueryRecieved(CallbackQuery callbackQuery)
        {
            await _botClient.SendMessage(
                chatId: callbackQuery.Message!.Chat.Id,
                text: $"{callbackQuery.Data}");
        }

        private Task UnknownUpdadeTypeHandler(Update update)
        {
            _logger.LogInformation($"Unknown update type : {update.Type}");

            return Task.CompletedTask;
        }
    }
}
