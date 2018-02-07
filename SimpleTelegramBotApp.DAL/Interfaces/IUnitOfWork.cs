using SimpleTelegramBotApp.DAL.Entities;

namespace SimpleTelegramBotApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Translation> TranslationsRepository { get; }
    }
}