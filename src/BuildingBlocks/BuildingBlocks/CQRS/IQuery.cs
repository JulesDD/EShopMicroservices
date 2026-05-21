using MediatR;

namespace BuildingBlocks.CQRS;

// Marker interface for queries without a response
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}
