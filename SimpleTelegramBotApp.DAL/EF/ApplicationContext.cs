using Microsoft.EntityFrameworkCore;
using SimpleTelegramBotApp.DAL.Configuration;
using SimpleTelegramBotApp.DAL.Entities;

namespace SimpleTelegramBotApp.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        private IConnectionStringsConfiguration _connectionConfiguration;

        public DbSet<Translation> Translations { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext(IConnectionStringsConfiguration connectionConfiguration)
        {
            _connectionConfiguration = connectionConfiguration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionConfiguration != null)
                optionsBuilder.UseSqlite(_connectionConfiguration.DefaultConnection);
        }
    }
}
