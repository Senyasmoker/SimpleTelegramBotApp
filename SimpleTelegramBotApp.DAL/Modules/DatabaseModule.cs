using Autofac;
using SimpleTelegramBotApp.DAL.EF;
using SimpleTelegramBotApp.DAL.Interfaces;

namespace SimpleTelegramBotApp.DAL.Modules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}