using Microsoft.EntityFrameworkCore;
using SimpleApi.Domain.DB.Configuragion;
using SimpleApi.Domain.Model;

namespace SimpleApi.Domain.DB.Configuration
{
    public class StorageContext : DbContext
    {
        public DbSet<NewsItem> NewsItems { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public StorageContext()
        {
        }

        public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsItemMap());
            modelBuilder.ApplyConfiguration(new SubscriptionMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}