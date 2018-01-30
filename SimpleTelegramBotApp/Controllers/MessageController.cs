using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleTelegramBotApp.BLL.Interfaces;
using Telegram.Bot.Types;

namespace SimpleTelegramBotApp.Controllers
{
    public class MessageController : Controller
    {
        private IBotService BotService { get; }

        public MessageController(IBotService botService)
        {
            BotService = botService;
        }

        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var message = update.Message;
            var client = await BotService.GetAsync();

            return Ok();
        }
    }
}