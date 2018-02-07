using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleTelegramBotApp.BLL.Configuration;
using SimpleTelegramBotApp.BLL.Interfaces;
using SimpleTelegramBotApp.DAL.Entities;
using SimpleTelegramBotApp.DAL.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SimpleTelegramBotApp.BLL.Services
{
    public class TranslationBotService : ITranslationBotService
    {
        private ITelegramBotClient _client;
        private readonly IBotConfiguration _botConfiguration;

        private IUnitOfWork UnitOfWork { get; }
        private ITranslationService TranslationService { get; }

        public TranslationBotService(IBotConfiguration botConfiguration,
            IUnitOfWork unitOfWork,
            ITranslationService translationService)
        {
            _botConfiguration = botConfiguration;
            UnitOfWork = unitOfWork;
            TranslationService = translationService;
        }

        public async Task ProcessMessageAsync(Message message)
        {
            await InitClient();

            var translatedText = await GetTranslationAsync(message.Text, "en");

            await _client.SendTextMessageAsync(message.Chat.Id, translatedText);
        }

        public async Task InitClient()
        {
            if (_client != null)
            {
                return;
            }

            _client = new TelegramBotClient(_botConfiguration.Key);
            var hook = string.Concat(_botConfiguration.Url, _botConfiguration.UpdateBaseApiPath);
            await _client.SetWebhookAsync(hook);
        }

        private async Task<string> GetTranslationAsync(string text, string lang)
        {
            var separators = new[] { '.', '!', '?', ';' };
            var parts = Regex.Split(text, $@"(?<=[{string.Join("", separators)}])");

            var sb = new StringBuilder();
            foreach (var part in parts)
            {
                if (string.IsNullOrWhiteSpace(part))
                    continue;

                if (separators.All(s => s.ToString() != part))
                {
                    var translatePart = await TranslatePartAsync(part, lang);
                    sb.Append(translatePart);
                }
                else
                {
                    sb.Append(part);
                }
            }

            return sb.ToString();
        }

        private async Task<string> TranslatePartAsync(string text, string lang)
        {
            var translated = string.Empty;

            var repTranslations = UnitOfWork.TranslationsRepository.Get(t => t.SourceText.ToLower() == text.ToLower());
            if (repTranslations.Any())
            {
                var translation = repTranslations.FirstOrDefault();
                translated = translation?.TranslatedText;
            }
            else
            {
                var translateResult = await TranslationService.Translate(text, lang);
                var fromToResult = translateResult.Lang.Split('-');

                if (translateResult.Text.Any())
                {
                    translated = translateResult.Text.FirstOrDefault();
                    UnitOfWork.TranslationsRepository.Create(new Translation
                    {
                        SourceText = text,
                        TranslatedText = translated,
                        From = fromToResult.FirstOrDefault() ?? "ru",
                        To = fromToResult.Skip(1).FirstOrDefault() ?? "en"
                    });
                }
            }

            return translated;
        }
    }
}
