using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace challenge_features.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }


        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var results = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var errors = results.SelectMany(r => r.Errors).Where(e => e != null).ToList();

                if (errors.Any())
                    throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
