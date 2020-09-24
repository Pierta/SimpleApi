using SimpleApi.Infrastructure.Cqs.Impl;
using System;

namespace SimpleApi.Domain.BusinessLogic.News
{
    public class GetNewsItemsQuery : Query
    {
        public Guid SubscriptionId { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}