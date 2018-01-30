using Autofac;
using GuessNumberWebApp.DAL.EF;

namespace DiplomaManager.DAL.Modules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
