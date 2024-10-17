using MediatR;

namespace Shared.CQRS;

public interface ICommand : ICommand<Unit> // Command that does not return a response
{

}
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
