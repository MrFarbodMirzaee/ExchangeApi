using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.User.UploadByExcleFile;

[Validator]
public class UserUploadByExcleCommandValidator : AbstractValidator<UserUploadByExcleCommand>
{
    public UserUploadByExcleCommandValidator()
    {
        var allowedExtensions = new[] { ".xlsx" };

        RuleFor(x => x.ImportFile)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=>string.Format(Validations.Required, nameof(item.ImportFile)))
            .Must(file => file != null && file.Length > 0)
            .WithMessage(item=> string.Format(Validations.GreatherThan, nameof(item.ImportFile) ,0))
            .Must(file =>
            {
                var extension = Path.GetExtension(file?.FileName ?? "fileExtension").ToLower();
                return allowedExtensions.Contains(extension);
            })
            .WithMessage(command =>
            {
                var extension = Path.GetExtension(command.ImportFile?.FileName ?? "fileExtension").ToLower();
                return string.Format(Validations.InvalidFormat, extension);
            });


        RuleFor(x => x.HasHeader)
            .NotNull()
            .WithMessage(file => string.Format
                (Validations.Required,nameof(file.HasHeader)));
    }
}