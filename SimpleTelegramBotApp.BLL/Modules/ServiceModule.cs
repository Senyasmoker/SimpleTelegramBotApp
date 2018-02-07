using Autofac;
using AutoMapper;
using SimpleTelegramBotApp.BLL.DTOs;
using SimpleTelegramBotApp.BLL.Interfaces;
using SimpleTelegramBotApp.BLL.Services;
using SimpleTelegramBotApp.DAL.Entities;

namespace SimpleTelegramBotApp.BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TranslationBotService>().As<ITranslationBotService>();
            builder.RegisterType<TranslationService>().As<ITranslationService>();
            builder.RegisterType<TranslationsService>().As<ICrudService<TranslationDto>>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Translation, TranslationDto>();

                cfg.CreateMap<TranslationDto, Translation>();
            });
        }
    }
}
