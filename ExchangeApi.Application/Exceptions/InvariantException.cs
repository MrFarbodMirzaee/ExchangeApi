namespace ExchangeApi.Application.Exceptions;

public sealed class InvariantException(IReadOnlyCollection<InvariantError> errors) : Exception("Invariant Failed") {
    public IReadOnlyCollection<InvariantError> Errors { get; } = errors;
}

public sealed record InvariantError(string PropertyName, string ErrorMessage);