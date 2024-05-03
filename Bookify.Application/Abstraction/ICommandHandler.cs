using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Abstraction
{
    public interface ICommandHandler<Tcommand> : IRequestHandler<Tcommand, Result>
       where Tcommand : ICommand//set Constaint that TCommand muse Be of ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    { }
}
