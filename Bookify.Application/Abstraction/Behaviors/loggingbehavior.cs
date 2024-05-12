using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstraction.Behaviors
{
    public class loggingBehavior<TRequest, Tresponse> :
        IPipelineBehavior<TRequest, Tresponse>
        where TRequest : IBaseCommand
    {

        private readonly ILogger<Tresponse> _logger;

        public loggingBehavior(ILogger<Tresponse> logger)
        {
            _logger = logger;
        }

        public async Task<Tresponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<Tresponse> next, 
            CancellationToken cancellationToken)
        {

            var name = request.GetType().Name;
            try
            {
                _logger.LogInformation("Excecuting command {command} ", name);

                var result = await next();
                _logger.LogInformation("command {command} processed successfully ", name);

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Command {command} processing failed!", name);

                throw;
            }

        }
    }
}
