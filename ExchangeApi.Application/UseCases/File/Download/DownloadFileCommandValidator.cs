using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.File.Download;

[Validator]
public class DownloadFileCommandValidator : AbstractValidator<DownloadFileCommand>
{
    public DownloadFileCommandValidator()
    {
        RuleFor(prop => prop.FileId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.FileId)));
    }
}