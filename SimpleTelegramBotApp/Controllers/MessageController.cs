using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleTelegramBotApp.BLL.Interfaces;
using Telegram.Bot.Types;

namespace SimpleTelegramBotApp.Controllers
{
    public class MessageController : Controller
    {
        private ITranslationBotService BotService { get; }

        public MessageController(ITranslationBotService botService)
        {
            BotService = botService;
        }

        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            await BotService.ProcessMessageAsync(update.Message);
            
            return Ok();
        }
    }
}