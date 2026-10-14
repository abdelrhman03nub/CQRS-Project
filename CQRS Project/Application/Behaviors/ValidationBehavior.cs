
using FluentValidation;
using MediatR;

namespace CQRS_Project.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(
            IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = new List<FluentValidation.Results.ValidationFailure>();

            foreach (var validator in _validators)
            {
                var result = await validator.ValidateAsync(
                    context,
                    cancellationToken);

                errors.AddRange(result.Errors);
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
