using MediatR;

namespace Domain.Common.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
