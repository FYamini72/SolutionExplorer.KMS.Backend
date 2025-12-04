using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class StorageConditionCreateDtoValidator : AbstractValidator<StorageConditionCreateDto>
    {
        public StorageConditionCreateDtoValidator()
        {
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<StorageConditionCreateDto> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("وارد کردن عنوان الزامی است")
                .NotNull()
                .WithMessage("وارد کردن عنوان الزامی است");

            return base.ValidateAsync(context, cancellation);
        }
    }
}