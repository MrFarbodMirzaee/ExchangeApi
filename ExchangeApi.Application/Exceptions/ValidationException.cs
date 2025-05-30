namespace ExchangeApi.Application.Exceptions;

public sealed class ValidationException(IReadOnlyCollection<ValidationError> errors) : Exception("Validation Failed") {
    public IReadOnlyCollection<ValidationError> Errors { get; } = errors;
}

public sealed record ValidationError(string PropertyName, string ErrorMessage);