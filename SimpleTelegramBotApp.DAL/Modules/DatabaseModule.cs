using Autofac;
using SimpleTelegramBotApp.DAL.EF;

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