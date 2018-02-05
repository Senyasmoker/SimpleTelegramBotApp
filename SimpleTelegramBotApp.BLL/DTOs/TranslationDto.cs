namespace SimpleTelegramBotApp.BLL.DTOs
{
    public class TranslationDto
    {
        public int Id { get; set; }

        public string SourceText { get; set; }

        public string TranslatedText { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}
