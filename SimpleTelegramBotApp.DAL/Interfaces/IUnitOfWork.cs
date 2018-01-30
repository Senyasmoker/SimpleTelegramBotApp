using SimpleTelegramBotApp.DAL.Entities;
using SimpleTelegramBotApp.DAL.Interfaces;

namespace SimpleTelegramBotApp.DAL.EF
{
    public interface IUnitOfWork
    {
        IGenericRepository<Translation> TranslationsRepository { get; }
    }
}