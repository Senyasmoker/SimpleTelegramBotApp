using System.Collections.Generic;

namespace SimpleTelegramBotApp.BLL.DTOs
{
    public class TranslationResult
    {
        public string Lang { get; set; }

        public IEnumerable<string> Text { get; set; }
    }
}
