using SimpleApi.Infrastructure.Cqs.Interfaces;

namespace SimpleApi.Infrastructure.Cqs.Impl
{
    public abstract class Command : Request, ICommand
    {
    }
}