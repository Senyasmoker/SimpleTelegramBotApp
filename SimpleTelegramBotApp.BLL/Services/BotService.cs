using SimpleTelegramBotApp.BLL.Configuration;
using SimpleTelegramBotApp.BLL.Interfaces;
using System.Threading.Tasks;
using Telegram.Bot;

namespace SimpleTelegramBotApp.BLL
{
    public class BotService : IBotService
    {
        private ITelegramBotClient _client;
        private IBotConfiguration _botConfiguration;

        public BotService(IBotConfiguration botConfiguration)
        {
            _botConfiguration = botConfiguration;
        }

        public async Task<ITelegramBotClient> GetAsync()
        {
            if (_client != null)
            {
                return _client;
            }

            _client = new TelegramBotClient(_botConfiguration.Key);
            var hook = string.Format(_botConfiguration.Url, "api/message/update");
            await _client.SetWebhookAsync(hook);

            return _client;
        }
    }
}
