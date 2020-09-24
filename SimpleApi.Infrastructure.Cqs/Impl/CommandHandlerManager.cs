using Microsoft.Extensions.DependencyInjection;
using SimpleApi.Infrastructure.Cqs.Interfaces;
using System;
using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Impl
{
    public class CommandHandlerManager: ICommandHandlerManager
    {
        private readonly IServiceProvider serviceProvider;

        public CommandHandlerManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TResult Manage<TParameter, TResult>(TParameter command) where TParameter : ICommand where TResult : IResult
        {
            var handler = serviceProvider.GetService<ICommandHandler<TParameter, TResult>>();
            return handler.Handle(command);
        }

        public async Task<TResult> ManageAsync<TParameter, TResult>(TParameter command) where TParameter : ICommand where TResult : IResult
        {
            var handler = serviceProvider.GetService<ICommandHandler<TParameter, TResult>>();
            return await handler.HandleAsync(command);
        }
    }
}