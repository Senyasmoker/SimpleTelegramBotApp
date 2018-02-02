using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTelegramBotApp.BLL.Interfaces;
using Telegram.Bot.Types;

namespace SimpleTelegramBotApp.Controllers
{
    public class MessageController : Controller
    {
        private ITranslationBotService BotService { get; }
        private ILogger<MessageController> Logger { get; }

        public MessageController(ITranslationBotService botService,
            ILogger<MessageController> logger)
        {
            BotService = botService;
            Logger = logger;
        }

        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            Logger.LogInformation("Received Bot Message: " + update.Message.Text);

            await BotService.ProcessMessageAsync(update.Message);
            
            return Ok();
        }
    }
}