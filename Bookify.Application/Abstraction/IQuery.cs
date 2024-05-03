using MediatR;

namespace Bookify.Application.Abstraction
{
    public interface IQuery<TResponse>: IRequest<Result<TResponse>> // My query Returning Rersult Of Tresponse object.
    {
    }
}
