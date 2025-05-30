namespace ExchangeApi.Application.Exceptions;

public sealed class BadDataException(IReadOnlyCollection<BadDataError> errors) : Exception("Bad Data") {
    public IReadOnlyCollection<BadDataError> Errors { get; } = errors;
}

public sealed record BadDataError(string PropertyName, string ErrorMessage);