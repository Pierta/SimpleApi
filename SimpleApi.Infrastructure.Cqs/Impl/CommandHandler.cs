using Microsoft.Extensions.Logging;
using SimpleApi.Infrastructure.Cqs.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Impl
{
    public abstract class CommandHandler<TRequest, TResult> : ICommandHandler<TRequest, TResult>
        where TRequest : ICommand
        where TResult : IResult, new()
    {
        protected readonly ILogger<CommandHandler<TRequest, TResult>> logger;

        protected CommandHandler(ILogger<CommandHandler<TRequest, TResult>> logger)
        {
            this.logger = logger;
        }

        public TResult Handle(TRequest command)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            TResult response;

            try
            {
                response = DoHandle(command);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, $"Error in '{typeof(TRequest).Name}' CommandHandler.");
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logger.LogDebug($"Response for command '{typeof(TRequest).Name}' served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return response;
        }

        public async Task<TResult> HandleAsync(TRequest command)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            Task<TResult> response;

            try
            {
                response = DoHandleAsync(command);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, $"Error in '{typeof(TRequest).Name}' CommandHandler.");
                throw;
            }
            finally
            {
                stopWatch.Stop();
                logger.LogDebug($"Response for command '{typeof(TRequest).Name}' served (elapsed time: {stopWatch.ElapsedMilliseconds} msec)");
            }

            return await response;
        }

        protected abstract TResult DoHandle(TRequest request);

        protected abstract Task<TResult> DoHandleAsync(TRequest request);
    }
}