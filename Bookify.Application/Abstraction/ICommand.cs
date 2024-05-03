using MediatR;

namespace Bookify.Application.Abstraction
{
    public interface IBaseCommand
    {
    }

    public class ICommand:IRequest<Result>,IBaseCommand
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }
}
