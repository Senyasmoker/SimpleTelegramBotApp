using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SimpleTelegramBotApp.BLL.Interfaces
{
    public interface ITranslationBotService
    {
        Task ProcessMessageAsync(Message message);
    }
}
