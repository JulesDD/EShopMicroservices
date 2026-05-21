using MediatR;

namespace BuildingBlocks.CQRS;

// Marker interface for query handlers
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{

}
