using SimpleApi.Domain.Model;
using System;
using System.Linq.Expressions;

namespace SimpleApi.Domain.Specs
{
    public class FindNewsBySubscription
    {
        private readonly Guid subscriptionId;

        public FindNewsBySubscription(Guid subscriptionId)
        {
            this.subscriptionId = subscriptionId;
        }

        public Expression<Func<NewsItem, bool>> IsSatisfiedBy()
        {
            return n => n.SubscriptionId == subscriptionId;
        }
    }
}