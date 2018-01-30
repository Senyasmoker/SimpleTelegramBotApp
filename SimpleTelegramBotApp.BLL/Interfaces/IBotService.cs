using System.Threading.Tasks;
using Telegram.Bot;

namespace SimpleTelegramBotApp.BLL.Interfaces
{
    public interface IBotService
    {
        Task<ITelegramBotClient> GetAsync();
    }
}
