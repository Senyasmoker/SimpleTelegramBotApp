using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SimpleTelegramBotApp.BLL.Interfaces
{
    public interface ITranslationBotService
    {
        Task InitClient();

        Task ProcessMessageAsync(Message message);
    }
}
