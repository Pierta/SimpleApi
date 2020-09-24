using System;

namespace SimpleApi.Domain.Model
{
    public class NewsItem
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime Updated { get; set; }

        public DateTime Created { get; set; }

        public Guid SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }
    }
}