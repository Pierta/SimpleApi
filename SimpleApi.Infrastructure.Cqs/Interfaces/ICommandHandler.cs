using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Interfaces
{
    public interface ICommandHandler<in TParameter, TResult> where TParameter : ICommand where TResult : IResult
    {
        TResult Handle(TParameter command);

        Task<TResult> HandleAsync(TParameter command);
    }
}