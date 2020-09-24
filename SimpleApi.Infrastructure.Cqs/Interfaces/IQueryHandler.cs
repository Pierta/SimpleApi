using System.Threading.Tasks;

namespace SimpleApi.Infrastructure.Cqs.Interfaces
{
    public interface IQueryHandler<in TParameter, TResult> where TResult : IResult where TParameter : IQuery
    {
        TResult Retrieve(TParameter query);

        Task<TResult> RetrieveAsync(TParameter query);
    }
}