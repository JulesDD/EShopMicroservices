using MediatR;

namespace BuildingBlocks.CQRS;

// Marker interface for command handlers without a response
public interface ICommandHandler<in TCommand> :ICommandHandler<TCommand, Unit> 
    where TCommand : ICommand<Unit>
{
}

// Marker interface for command handlers with a response
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> 
    where TCommand : ICommand<TResponse> 
    where TResponse : notnull
{
}
