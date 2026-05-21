using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS;

// Marker interface for commands without a response
public interface ICommand : ICommand<Unit>
{
}

// Marker interface for commands with a response
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
