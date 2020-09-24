using SimpleApi.Domain.Model;
using SimpleApi.Infrastructure.Cqs.Interfaces;
using System.Collections.Generic;

namespace SimpleApi.Domain.BusinessLogic.News
{
    public class GetNewsItemsResult : IResult
    {
        public IEnumerable<NewsItem> NewsItems {get;set;}
    }
}