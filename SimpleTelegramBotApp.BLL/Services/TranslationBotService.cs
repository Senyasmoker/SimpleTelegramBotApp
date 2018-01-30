using SimpleTelegramBotApp.BLL.Configuration;
using SimpleTelegramBotApp.BLL.Interfaces;
using SimpleTelegramBotApp.DAL.EF;
using SimpleTelegramBotApp.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SimpleTelegramBotApp.BLL
{
    public class TranslationBotService : ITranslationBotService
    {
        private ITelegramBotClient _client;
        private IBotConfiguration _botConfiguration;

        private IUnitOfWork UnitOfWork { get; }
        private ITranslationService TranslationService { get; }

        public TranslationBotService(IBotConfiguration botConfiguration,
            IUnitOfWork unitOfWork,
            ITranslationService translationService)
        {
            _botConfiguration = botConfiguration;
            TranslationService = translationService;
        }

        public async Task ProcessMessageAsync(Message message)
        {
            await InitClient();

            var translatedText = await GetTranslationAsync(message.Text, "en");

            await _client.SendTextMessageAsync(message.Chat.Id, translatedText);
        }

        private async Task InitClient()
        {
            if (_client != null)
            {
                return;
            }

            _client = new TelegramBotClient(_botConfiguration.Key);
            var hook = string.Format(_botConfiguration.Url, "api/message/update");
            await _client.SetWebhookAsync(hook);
        }

        private async Task<string> GetTranslationAsync(string text, string lang)
        {
            string translated = string.Empty;

            var repTranslations = UnitOfWork.TranslationsRepository.Get(t => 
                t.SourceText.IndexOf(text, 0, StringComparison.OrdinalIgnoreCase) != -1);
            if (repTranslations.Any())
            {
                var translation = repTranslations.FirstOrDefault();
                translated = translation?.TranslatedText;
            }
            else
            {
                var translateResult = await TranslationService.Translate(text, lang);
                if (translateResult?.Text.Any() != null)
                {
                    translated = translateResult.Text.FirstOrDefault();
                    UnitOfWork.TranslationsRepository.Create(new Translation
                    {
                        SourceText = text,
                        TranslatedText = translated,
                        From = lang,
                        To = translateResult.Lang
                    });
                }
            }

            return translated;
        }
    }
}
