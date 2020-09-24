using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApi.Domain.Model;

namespace SimpleApi.Domain.DB.Configuration
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscriptions").HasKey(i => i.Id);

            builder.HasData(new Subscription[]
            {
                new Subscription
                {
                    Id = Subscription.DefaultId,
                    Name = "Free subscription",
                    Price = 0
                },
                new Subscription
                {
                    Id = Subscription.FullSubscriptionId,
                    Name = "Full subscription",
                    Price = 100
                }
            });
        }
    }
}