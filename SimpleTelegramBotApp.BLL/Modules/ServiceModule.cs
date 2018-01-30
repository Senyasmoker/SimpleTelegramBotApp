using Autofac;
using SimpleTelegramBotApp.BLL;
using SimpleTelegramBotApp.BLL.Interfaces;

namespace DiplomaManager.BLL.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TranslationBotService>().As<ITranslationBotService>();
        }
    }
}
