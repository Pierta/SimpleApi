using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleApi.Domain.Model;
using System;

namespace SimpleApi.Domain.DB.Configuragion
{
    public class NewsItemMap : IEntityTypeConfiguration<NewsItem>
    {
        public void Configure(EntityTypeBuilder<NewsItem> builder)
        {
            builder.ToTable("NewsItems").HasKey(i => i.Id);

            var now = DateTime.Now;
            builder.HasData(new NewsItem[]
            {
                new NewsItem
                {
                    Id = 1,
                    Title = "First news",
                    Author = "Greatest journalist ever",
                    ShortDescription = "Old lady from village 'Milk farm' found a huge bomb instead of eggplant!",
                    FullDescription = "Old lady from village 'Milk farm' found a huge bomb instead of eggplant!",
                    UpdatedBy = Guid.NewGuid(),
                    Updated = now,
                    Created = now,
                    SubscriptionId = Subscription.DefaultId
                },
                new NewsItem
                {
                    Id = 2,
                    Title = "Paid news",
                    Author = "Only for money author",
                    ShortDescription = "Great news!",
                    FullDescription = "Great news!",
                    UpdatedBy = Guid.NewGuid(),
                    Updated = now,
                    Created = now,
                    SubscriptionId = Subscription.FullSubscriptionId
                }
            });
        }
    }
}