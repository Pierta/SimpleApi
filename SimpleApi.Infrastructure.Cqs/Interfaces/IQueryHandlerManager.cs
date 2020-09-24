using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Interfaces
{
    public interface IQueryHandlerManager
    {
        TResult Manage<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IResult;

        Task<TResult> ManageAsync<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IResult;
    }
}