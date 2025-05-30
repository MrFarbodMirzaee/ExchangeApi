namespace ExchangeApi.Application.Exceptions;

public sealed class NotFoundException(NotFoundError error) : Exception("Not Found") {
    public NotFoundError Error { get; } = error;
}

public sealed record NotFoundError {
    public string ErrorMessage { get; set; }

    public NotFoundError(string entityName, bool isForSearch)
        => ErrorMessage = isForSearch
            ? $"No {entityName} was found with the specified criteria"
            : $"No {entityName} was found";

    public NotFoundError(long id, string entityName)
        => ErrorMessage = $"No {entityName} with ID: \"{id}\" was found";

    public NotFoundError(IEnumerable<long> ids, string entityName)
        => ErrorMessage = $"No {entityName} with IDs: \"{string.Join(", ", ids)}\" was found";

    public NotFoundError(long parentId, string entityName, string parentEntityName)
        => ErrorMessage = $"No {entityName} with {parentEntityName}ID: \"{parentId}\" was found";

    public NotFoundError(long id, long parentId, string entityName, string parentEntityName)
        => ErrorMessage = $"No {entityName} with ID: \"{id}\" and {parentEntityName}ID: \"{parentId}\" was found";
}