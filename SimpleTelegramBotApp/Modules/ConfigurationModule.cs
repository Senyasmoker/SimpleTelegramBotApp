﻿using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SimpleTelegramBotApp.BLL.Configuration;
using SimpleTelegramBotApp.DAL.Configuration;

namespace SimpleTelegramBotApp.Modules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateConnectionStringsConfiguration).SingleInstance();
            builder.Register(CreateTranslationConfiguration).SingleInstance();
            builder.Register(CreateBotConfiguration).SingleInstance();
        }

        private static IConnectionStringsConfiguration CreateConnectionStringsConfiguration(IComponentContext context)
        {
            var configuration = context.Resolve<IConfiguration>();

            var result = new ConnectionStringsConfiguration();

            new ConfigureFromConfigurationOptions<ConnectionStringsConfiguration>(configuration.GetSection("ConnectionStrings"))
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

        private class ConnectionStringsConfiguration : IConnectionStringsConfiguration
        {
            public string DefaultConnection { get; set; }
        }

        private class TranslationConfiguration : ITranslationConfiguration
        {
            public string BaseUrl { get; set; }
            public string TranslateBaseApiPath { get; set; }
            public string ApiKey { get; set; }
        }

        private class BotConfiguration : IBotConfiguration
        {
            public string Url { get; set; }
            public string UpdateBaseApiPath { get; set; }
            public string Name { get; set; }
            public string Key { get; set; }
        }

        #endregion
    }
}
