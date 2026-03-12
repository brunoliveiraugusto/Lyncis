using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Lyncis.Post.Api.Middlewares
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

            var problemDetails = exception switch
            {
                ValidationException validationException => new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Failed",
                    Detail = "One or more validation errors ocurred",
                    Extensions =
                    {
                        ["errors"] = validationException.Errors
                            .Select(e => new { e.PropertyName, e.ErrorMessage })
                    }
                },
                _ => new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error",
                    Detail = "An unexpected error occurred on our end"
                }
            };

            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
