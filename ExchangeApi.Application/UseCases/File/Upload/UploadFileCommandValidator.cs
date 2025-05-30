using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.File.Upload;

[Validator]
public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
{
    public UploadFileCommandValidator()
    {
        var allowedExtensions = new[] { ".jpeg", ".jpg", ".png" };

        RuleFor(x => x.File)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=>string.Format(Validations.Required, nameof(item.File)))
            .Must(file => file != null && file.Length > 0)
            .WithMessage(item => string.Format(Validations.GreatherThan, nameof(item.File), 0))
            .Must(file =>
            {
                var extension = Path.GetExtension(file?.FileName ?? "fileExtension").ToLower();
                return allowedExtensions.Contains(extension);
            })
            .WithMessage(command =>
            {
                var extension = Path.GetExtension(command.File?.FileName ?? "fileExtension").ToLower();
                return string.Format(Validations.InvalidFormat, extension);
            });
    }
}