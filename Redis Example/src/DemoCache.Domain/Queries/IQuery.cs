using MediatR;

namespace DemoCache.Domain.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
