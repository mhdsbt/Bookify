using Bookify.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Bookify.Application.Abstraction.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var validationErros = _validators.
                 Select(validator => validator.Validate(context))
                 .Where(validationResult => validationResult.Errors.Any())
                 .SelectMany(validationResult => validationResult.Errors)
                 .Select(validationfailure => new ValidationError(
                     validationfailure.PropertyName,
                     validationfailure.ErrorMessage
                     ))
                 .ToList();

            if (validationErros.Any())
            {
                throw new Exceptions.ValidationException(validationErros);
            }

            return await next();
        }
    }
}
