using SimpleTelegramBotApp.BLL.DTOs;
using System.Threading.Tasks;

namespace SimpleTelegramBotApp.BLL.Interfaces
{
    public interface ITranslationService
    {
        Task<TranslationResult> Translate(string text, string lang);
    }
}