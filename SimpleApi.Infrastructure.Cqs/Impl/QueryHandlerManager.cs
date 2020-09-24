using Microsoft.Extensions.DependencyInjection;
using SimpleApi.Infrastructure.Cqs.Interfaces;
using System;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Impl
{
    public class QueryHandlerManager : IQueryHandlerManager
    {
        private readonly IServiceProvider serviceProvider;

        public QueryHandlerManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TResult Manage<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IResult
        {
            var handler = serviceProvider.GetService<IQueryHandler<TParameter, TResult>>();
            return handler.Retrieve(query);
        }

        public async Task<TResult> ManageAsync<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IResult
        {
            var handler = serviceProvider.GetService<IQueryHandler<TParameter, TResult>>();
            return await handler.RetrieveAsync(query);
        }
    }
}