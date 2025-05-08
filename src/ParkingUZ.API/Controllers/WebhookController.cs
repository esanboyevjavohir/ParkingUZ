using Microsoft.AspNetCore.Mvc;
using ParkingUZ.Application.Services.Implement;
using Telegram.Bot.Types;

namespace ParkingUZ.API.Controllers
{
    public class WebhookController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] HandleBotService handleBotService,
            [FromBody] Update update)
        {
            await handleBotService.EchoAsync(update);

            return Ok();
        }
    }
}
