using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Domain.BusinessLogic.News;
using SimpleApi.Domain.Model;
using SimpleApi.Infrastructure.Cqs.Interfaces;
using SimpleApi.Model;
using SimpleApi.ModelMapping;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IQueryHandlerManager queryHandlerManager;
        private readonly ICommandHandlerManager commandHandlerManager;

        public NewsController(IQueryHandlerManager queryHandlerManager, ICommandHandlerManager commandHandlerManager)
        {
            this.queryHandlerManager = queryHandlerManager;
            this.commandHandlerManager = commandHandlerManager;
        }

        [HttpGet("free")]
        [Authorize]
        public IEnumerable<NewsItemView> Get()
        {
            var getNewsItemsQuery = new GetNewsItemsQuery
            {
                SubscriptionId = Subscription.DefaultId,
                PageNumber = 1,
                PageSize = 20
            };
            var getNewsItemsResult = queryHandlerManager.Manage<GetNewsItemsQuery, GetNewsItemsResult>(getNewsItemsQuery);
            
            // Map domain model to view
            var newsItemsView = getNewsItemsResult.NewsItems
                .Select(ModelToViewMapper.ConvertToView);

            return newsItemsView;
        }

        [HttpGet("paid")]
        [Authorize("read:paid-subscriptions")]
        public IEnumerable<NewsItemView> GetPaidNews()
        {
            var getNewsItemsQuery = new GetNewsItemsQuery
            {
                SubscriptionId = Subscription.FullSubscriptionId,
                PageNumber = 1,
                PageSize = 20
            };
            var getNewsItemsResult = queryHandlerManager.Manage<GetNewsItemsQuery, GetNewsItemsResult>(getNewsItemsQuery);

            // Map domain model to view
            var newsItemsView = getNewsItemsResult.NewsItems
                .Select(ModelToViewMapper.ConvertToView);

            return newsItemsView;
        }

        [HttpPost]
        [Authorize]
        public long Post(NewsItemView newNewsItemView)
        {
            var newNewsItem = ModelToViewMapper.ConvertToModel(newNewsItemView);
            var insertNewsItemCommand = new InsertNewsItemCommand
            {
                NewNewsItem = newNewsItem
            };

            var insertNewNewsItemResult = commandHandlerManager.Manage<InsertNewsItemCommand, InsertNewsItemResult>(insertNewsItemCommand);
            return insertNewNewsItemResult.NewNewsItemId;
        }
    }
}