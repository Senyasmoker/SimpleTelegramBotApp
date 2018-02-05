using AutoMapper;
using SimpleTelegramBotApp.BLL.DTOs;
using SimpleTelegramBotApp.BLL.Interfaces;
using SimpleTelegramBotApp.DAL.EF;
using SimpleTelegramBotApp.DAL.Entities;
using System.Collections.Generic;

namespace SimpleTelegramBotApp.BLL.Services
{
    public class TranslationsService : ICrudService<TranslationDto>
    {
        private IUnitOfWork _db;

        public TranslationsService(IUnitOfWork db)
        {
            _db = db;
        }

        public void Create(TranslationDto item)
        {
            var translation = Mapper.Map<TranslationDto, Translation>(item);

            _db.TranslationsRepository.Create(translation);
        }

        public void Delete(int id)
        {
            _db.TranslationsRepository.Remove(id);
        }

        public IEnumerable<TranslationDto> Get()
        {
            var translations = _db.TranslationsRepository.Get();

            return Mapper.Map<IEnumerable<Translation>, IEnumerable<TranslationDto>>(translations);
        }

        public TranslationDto Get(int id)
        {
            var translation = _db.TranslationsRepository.FindById(id);

            return Mapper.Map<Translation, TranslationDto>(translation);
        }

        public void Update(TranslationDto item)
        {
            var translation = Mapper.Map<TranslationDto, Translation>(item);

            _db.TranslationsRepository.Update(translation);
        }
    }
}
