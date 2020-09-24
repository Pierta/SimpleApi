using Microsoft.Extensions.Logging;
using SimpleApi.Domain.Model;
using SimpleApi.Domain.Specs;
using SimpleApi.Infrastructure.Cqs.Impl;
using SimpleApi.Infrastructure.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Domain.BusinessLogic.News
{
    public class GetNewsItemsQueryHandler : QueryHandler<GetNewsItemsQuery, GetNewsItemsResult>
    {
        private readonly IRepository<NewsItem, long> repository;
        
        public GetNewsItemsQueryHandler(ILogger<GetNewsItemsQueryHandler> logger, IRepository<NewsItem, long> repository)
            : base(logger)
        {
            this.repository = repository;
        }

        protected override GetNewsItemsResult Handle(GetNewsItemsQuery request)
        {
            var result = new GetNewsItemsResult();

            var newsItemSpec = new FindNewsBySubscription(request.SubscriptionId);
            var newsItemQuery = repository.FindAllByExpression(newsItemSpec.IsSatisfiedBy())
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);
            result.NewsItems = newsItemQuery.ToList();

            return result;
        }

        protected override Task<GetNewsItemsResult> HandleAsync(GetNewsItemsQuery request)
        {
            throw new NotImplementedException();
        }
    }
}