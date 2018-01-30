using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SimpleTelegramBotApp.BLL.Configuration;
using SimpleTelegramBotApp.DAL.Configuration;

namespace DiplomaManager.Modules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateDatabaseConnectionConfiguration).SingleInstance();
            builder.Register(CreateTranslationConfiguration).SingleInstance();
            builder.Register(CreateBotConfiguration).SingleInstance();
        }

        private static IDatabaseConnectionConfiguration CreateDatabaseConnectionConfiguration(IComponentContext context)
        {
            var configuration = context.Resolve<IConfiguration>();

            var result = new DatabaseConnectionConfiguration();

            new ConfigureFromConfigurationOptions<DatabaseConnectionConfiguration>(configuration.GetSection("Data"))
                .Configure(result);

            return result;
        }

        private static ITranslationConfiguration CreateTranslationConfiguration(IComponentContext context)
        {
            var configuration = context.Resolve<IConfiguration>();

            var result = new TranslationConfiguration();

            new ConfigureFromConfigurationOptions<TranslationConfiguration>(configuration.GetSection("Translation"))
                .Configure(result);

            return result;
        }

        private static IBotConfiguration CreateBotConfiguration(IComponentContext context)
        {
            var configuration = context.Resolve<IConfiguration>();

            var result = new BotConfiguration();

            new ConfigureFromConfigurationOptions<BotConfiguration>(configuration.GetSection("Bot"))
                .Configure(result);

            return result;
        }

        #region Nested Class

        public class DatabaseConnectionConfiguration : IDatabaseConnectionConfiguration
        {
            public string ConnectionString { get; set; }
        }

        public class TranslationConfiguration : ITranslationConfiguration
        {
            public string BaseUrl { get; set; }
            public string TranslateBaseApiPath { get; set; }
            public string ApiKey { get; set; }
        }

        public class BotConfiguration : IBotConfiguration
        {
            public string Url { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        #endregion
    }
}
