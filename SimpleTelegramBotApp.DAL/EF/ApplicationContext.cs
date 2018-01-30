using Microsoft.EntityFrameworkCore;
using SimpleTelegramBotApp.DAL.Configuration;
using SimpleTelegramBotApp.DAL.Entities;

namespace SimpleTelegramBotApp.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        private IDatabaseConnectionConfiguration _connectionConfiguration;

        public DbSet<Translation> Translations { get; set; }

        public ApplicationContext(IDatabaseConnectionConfiguration connectionConfiguration)
        {
            _connectionConfiguration = connectionConfiguration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionConfiguration.ConnectionString);
        }
    }
}
