using SimpleTelegramBotApp.DAL.EF;
using SimpleTelegramBotApp.DAL.Entities;
using SimpleTelegramBotApp.DAL.Interfaces;
using System;

namespace GuessNumberWebApp.DAL.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationContext _db;
        private IGenericRepository<Translation> _translationsRepository;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IGenericRepository<Translation> TranslationsRepository
        {
            get
            {
                if (_translationsRepository == null)
                    _translationsRepository = new EFGenericRepository<Translation>(_db);
                return _translationsRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
