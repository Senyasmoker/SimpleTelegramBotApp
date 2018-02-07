using Microsoft.EntityFrameworkCore;
using SimpleTelegramBotApp.DAL.Configuration;
using SimpleTelegramBotApp.DAL.Entities;
using SimpleTelegramBotApp.DAL.Interfaces;
using System;

namespace SimpleTelegramBotApp.DAL.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _db;
        private IGenericRepository<Translation> _translationsRepository;

        public UnitOfWork(IConnectionStringsConfiguration connectionStringsConfiguration)
        {
            _db = new ApplicationContext(connectionStringsConfiguration);
            _db.Database.EnsureCreated();
        }

        public IGenericRepository<Translation> TranslationsRepository => 
            _translationsRepository ?? (_translationsRepository = new EFGenericRepository<Translation>(_db));

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
