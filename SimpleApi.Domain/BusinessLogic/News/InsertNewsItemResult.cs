using SimpleApi.Infrastructure.Cqs.Interfaces;

namespace SimpleApi.Domain.BusinessLogic.News
{
    public class InsertNewsItemResult : IResult
    {
        public long NewNewsItemId {get;set;}
    }
}