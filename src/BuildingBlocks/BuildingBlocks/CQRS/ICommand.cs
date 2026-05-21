using MediatR;

namespace BuildingBlocks.CQRS;

// Marker interface for commands without a response
public interface ICommand : ICommand<Unit>
{
}

// Marker interface for commands with a response
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
