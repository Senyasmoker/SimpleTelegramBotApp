using SimpleTelegramBotApp.DAL.Entities;
using SimpleTelegramBotApp.DAL.Interfaces;

namespace GuessNumberWebApp.DAL.EF
{
    public interface IUnitOfWork
    {
        IGenericRepository<Translation> TranslationsRepository { get; }
    }
}