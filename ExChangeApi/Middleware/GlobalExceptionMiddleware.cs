using Azure.Identity;
using ExchangeApi.Application.Exceptions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Middleware;

public sealed class GlobalExceptionMiddleware(
    RequestDelegate next,
    IWebHostEnvironment env,
    ILogger<GlobalExceptionMiddleware> logger) {
    public async Task InvokeAsync(HttpContext context) {
        try {
            await next(context);
            await HandleModelBindingErrors(context);
        }
        catch (DbUpdateException exception) when (exception.InnerException is SqlException sqlException) {
            await HandleDatabaseException(context, sqlException, exception);
        }
        // catch (IdentityResultException exception)
        // {
        //     logger.LogError(exception, "Identity result exception occurred: {Message}", exception.Message);
        //
        //     ErrorResponse errorResponse = new()
        //     {
        //         Status = StatusCodes.Status400BadRequest,
        //         Type = "IdentityOperationFailure",
        //         Title = "Identity operation error",
        //         Detail = $"One or more errors has occurred on {exception.OperationName}.",
        //         TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
        //     };
        //
        //     if (exception.IdentityResult.Errors is not null)
        //         errorResponse.Extensions["errors"] = exception.IdentityResult.Errors;
        //
        //     await SetResponse(context, errorResponse);
        // }
        catch (AuthenticationFailedException exception) {
            await HandleAuthenticationException(context, exception);
        }
        catch (FluentValidation.ValidationException exception) {
            await HandleValidationException(context, exception);
        }
        catch (InvariantException exception) {
            await HandleGenericException(context, exception, StatusCodes.Status400BadRequest, "InvariantFailure",
                "Invariant error",
                "One or more invariant rules have been violated.");
        }
        catch (BadDataException exception) {
            await HandleGenericException(context, exception, StatusCodes.Status400BadRequest, "BadData",
                "BadData error",
                "One or more properties have invalid values.");
        }
        catch (RelationDataException exception) {
            await HandleGenericException(context, exception, StatusCodes.Status400BadRequest, "RelationData",
                "RelationData error",
                "The Entity has relation with another entity.");
        }
        catch (NotFoundException exception) {
            await HandleGenericException(context, exception, StatusCodes.Status404NotFound, "NotFound",
                "NotFound error",
                exception.Error.ErrorMessage);
        }
        catch (Exception exception) {
            await HandleGenericException(context, exception, StatusCodes.Status500InternalServerError,
                "InternalServerError",
                "Internal Server Error", "An unexpected error occurred.");
        }
    }

    private Task HandleDatabaseException(HttpContext context, SqlException sqlException,
        DbUpdateException exception) {
        var errorResponse = new ErrorResponse {
            Status = StatusCodes.Status400BadRequest,
            Type = "DbUpdateFailure",
            Title = "Database update error",
            TechnicalDetails = !env.IsProduction() ? exception.InnerException?.Message : null,
            Detail = sqlException.Number switch {
                547 => "Invalid foreign key reference in provided IDs.",
                2601 => "A unique constraint violation occurred. Please check for uniqueness.",
                8152 => "One or more fields exceed the maximum allowed length.",
                53 => "Service is temporarily unavailable. Please try again later.",
                _ => "A database error occurred."
            }
        };

        logger.LogError(exception, "Database update exception: {Detail}", errorResponse.Detail);
        return SetResponse(context, errorResponse);
    }

    private Task HandleAuthenticationException(HttpContext context, AuthenticationFailedException exception) {
        return HandleGenericException(context, exception, StatusCodes.Status400BadRequest, "AuthenticationFailure",
            "Authentication Failed",
            $"Authentication failed: {exception.Message}");
    }

    private Task HandleValidationException(HttpContext context, FluentValidation.ValidationException exception) {
        logger.LogError(exception, "Validation exception: {Message}", exception.Message);

        var errorResponse = new ErrorResponse {
            Status = StatusCodes.Status400BadRequest,
            Type = "ValidationFailure",
            Title = "Validation error",
            Detail = "One or more validation errors occurred.",
            TechnicalDetails = !env.IsProduction() ? exception.StackTrace : null,
        };

        if (exception.Errors.Any()) {
            errorResponse.Extensions["errors"] =
                exception.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
        }

        return SetResponse(context, errorResponse);
    }

    private Task HandleGenericException(HttpContext context, Exception exception, int statusCode, string type,
        string title, string detail) {
        logger.LogError(exception, "{Type} exception: {Message}", type, exception.Message);

        var errorResponse = new ErrorResponse {
            Status = statusCode,
            Type = type,
            Title = title,
            Detail = detail,
            TechnicalDetails = !env.IsProduction() ? exception.StackTrace : null
        };

        return SetResponse(context, errorResponse);
    }

    private static async Task HandleModelBindingErrors(HttpContext context) {
        if (context.Response.StatusCode == StatusCodes.Status400BadRequest) {
            var modelStateErrors = context.Features.Get<IHttpRequestFeature>()?.Headers;

            if (modelStateErrors is { Count: > 0 }) {
                var errorResponse = new ErrorResponse {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "ModelBindingError",
                    Title = "Invalid request parameters",
                    Detail = "One or more query parameters have invalid values."
                };

                await SetResponse(context, errorResponse);
            }
        }
    }

    private static Task SetResponse(HttpContext context, ErrorResponse errorResponse) {
        context.Response.StatusCode = errorResponse.Status!.Value;
        return context.Response.WriteAsJsonAsync(errorResponse);
    }
}

public sealed class ErrorResponse : ProblemDetails {
    public string? TechnicalDetails { get; set; }
}