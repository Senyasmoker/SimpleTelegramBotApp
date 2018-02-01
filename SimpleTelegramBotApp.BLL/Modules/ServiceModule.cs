using Autofac;
using SimpleTelegramBotApp.BLL;
using SimpleTelegramBotApp.BLL.Interfaces;
using SimpleTelegramBotApp.BLL.Services;
using SimpleTelegramBotApp.DAL.Entities;

namespace DiplomaManager.BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TranslationBotService>().As<ITranslationBotService>();
            builder.RegisterType<TranslationsService>().As<ICrudService<Translation>>();
        }
    }
}
