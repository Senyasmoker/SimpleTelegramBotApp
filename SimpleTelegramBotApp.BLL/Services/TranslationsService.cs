using SimpleTelegramBotApp.BLL.Interfaces;
using SimpleTelegramBotApp.DAL.EF;
using SimpleTelegramBotApp.DAL.Entities;
using System;
using System.Collections.Generic;

namespace SimpleTelegramBotApp.BLL.Services
{
    public class TranslationsService : ICrudService<Translation>
    {
        private IUnitOfWork _db;

        public TranslationsService(IUnitOfWork db)
        {
            _db = db;
        }

        public void Create(Translation item)
        {
            _db.TranslationsRepository.Create(item);
        }

        public void Delete(int id)
        {
            _db.TranslationsRepository.Remove(id);
        }

        public IEnumerable<Translation> Get()
        {
            return _db.TranslationsRepository.Get();
        }

        public Translation Get(int id)
        {
            return _db.TranslationsRepository.FindById(id);
        }

        public void Update(Translation item)
        {
            _db.TranslationsRepository.Update(item);
        }
    }
}
