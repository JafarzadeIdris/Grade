using Common.Core.Commands;
using FluentValidation;
using MediatR;

namespace Common.Core.Validators
{
    public class ValidatorPipelineBehavior<TRequest, TResponse>
        (IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TRequest>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<TRequest>(request);
            var validationResponse = await Task.WhenAll(validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));

            var validationErrors = validationResponse.Where(x => x.Errors.Any()).SelectMany(x => x.Errors).ToList();

            if (validationErrors.Any())
                throw new ValidationException(validationErrors);
            return await next();
        }
    }
}
