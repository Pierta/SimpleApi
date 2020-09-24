using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Interfaces
{
    public interface ICommandHandlerManager
    {
        TResult Manage<TParameter, TResult>(TParameter command) where TParameter : ICommand where TResult : IResult;

        Task<TResult> ManageAsync<TParameter, TResult>(TParameter command) where TParameter : ICommand where TResult : IResult;
    }
}