using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS;

// Marker interface for queries without a response
public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}
