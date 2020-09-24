using SimpleApi.Domain.Model;
using SimpleApi.Infrastructure.Cqs.Impl;

namespace SimpleApi.Domain.BusinessLogic.News
{
    public class InsertNewsItemCommand : Command
    {
        public NewsItem NewNewsItem { get; set; }
    }
}