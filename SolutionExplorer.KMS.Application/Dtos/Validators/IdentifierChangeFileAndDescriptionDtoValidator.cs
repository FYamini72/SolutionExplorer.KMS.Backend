using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class IdentifierChangeFileAndDescriptionDtoValidator : AbstractValidator<IdentifierChangeFileAndDescriptionDto>
    {
        public IdentifierChangeFileAndDescriptionDtoValidator()
        {
            
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<IdentifierChangeFileAndDescriptionDto> context, CancellationToken cancellation = default)
        {

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("وارد کردن توضیحات الزامی است")
                .NotNull()
                .WithMessage("وارد کردن توضیحات الزامی است")
                .MaximumLength(1000)
                .WithMessage("حداکثر طول مجاز برای فیلد توضیحات 1000 کاراکتر است.");

            return base.ValidateAsync(context, cancellation);
        }
    }
}