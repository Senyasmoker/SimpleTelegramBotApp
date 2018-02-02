using Microsoft.EntityFrameworkCore;
using SimpleTelegramBotApp.DAL.Configuration;
using SimpleTelegramBotApp.DAL.Entities;
using SimpleTelegramBotApp.DAL.Interfaces;
using System;

namespace SimpleTelegramBotApp.DAL.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationContext _db;
        private IGenericRepository<Translation> _translationsRepository;

        public UnitOfWork(IConnectionStringsConfiguration connectionStringsConfiguration)
        {
            _db = new ApplicationContext(connectionStringsConfiguration);
            _db.Database.EnsureCreated();
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
