
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Exceptions
{
    public class ValidationExceptionHandler
    {
        public static ValidationProblemDetails Handle(ValidationException exception)
        {
            var errors = exception.Errors
                .GroupBy(error => error.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(error => error.ErrorMessage).ToArray()
                );

            return new ValidationProblemDetails(errors)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "One or more validation errors occurred."
            };
        }
    }
}
