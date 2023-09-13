using MediatR;

namespace DemoCache.Domain.Commands
{
    public interface ICommand : IRequest
    {
    }
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
