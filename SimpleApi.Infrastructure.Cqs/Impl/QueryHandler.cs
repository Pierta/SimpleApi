using Microsoft.Extensions.Logging;
using SimpleApi.Infrastructure.Cqs.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Impl
{
    public abstract class QueryHandler<TParameter, TResult> : IQueryHandler<TParameter, TResult>
            where TResult : IResult, new()
            where TParameter : IQuery, new()
    {
        protected readonly ILogger<QueryHandler<TParameter, TResult>> logger;

        protected QueryHandler(ILogger<QueryHandler<TParameter, TResult>> logger)
        {
            this.logger = logger;
        }

        public TResult Retrieve(TParameter query)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            TResult queryResult;

            try
            {
                queryResult = Handle(query);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, $"Error in '{typeof(TParameter).Name}' QueryHandler.");
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logger.LogDebug($"Response for query '{typeof(TParameter).Name}' served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return queryResult;
        }

        public async Task<TResult> RetrieveAsync(TParameter query)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Task<TResult> queryResult;

            try
            {
                queryResult = HandleAsync(query);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, $"Error in '{typeof(TParameter).Name}' QueryHandler.");
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logger.LogDebug($"Response for query '{typeof(TParameter).Name}' served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return await queryResult;
        }

        protected abstract TResult Handle(TParameter request);

        protected abstract Task<TResult> HandleAsync(TParameter request);
    }
}