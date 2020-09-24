using Microsoft.Extensions.Logging;
using SimpleApi.Domain.Model;
using SimpleApi.Infrastructure.Cqs.Impl;
using SimpleApi.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace SimpleApi.Domain.BusinessLogic.News
{
    public class InsertNewsItemCommandHandler : CommandHandler<InsertNewsItemCommand, InsertNewsItemResult>
    {
        private readonly IRepository<NewsItem, long> repository;
        
        public InsertNewsItemCommandHandler(ILogger<InsertNewsItemCommandHandler> logger, IRepository<NewsItem, long> repository)
            : base(logger)
        {
            this.repository = repository;
        }

        protected override InsertNewsItemResult DoHandle(InsertNewsItemCommand request)
        {
            var result = new InsertNewsItemResult();

            repository.Add(request.NewNewsItem);
            repository.CommitChanges();
            result.NewNewsItemId = request.NewNewsItem.Id;

            return result;
        }

        protected override Task<InsertNewsItemResult> DoHandleAsync(InsertNewsItemCommand request)
        {
            throw new NotImplementedException();
        }
    }
}