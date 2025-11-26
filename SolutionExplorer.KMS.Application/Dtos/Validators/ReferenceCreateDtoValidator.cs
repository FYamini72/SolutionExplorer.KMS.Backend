using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class ReferenceCreateDtoValidator : AbstractValidator<ReferenceCreateDto>
    {
        public ReferenceCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ReferenceCreateDto> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("وارد کردن اسم منبع الزامی است")
                .NotNull()
                .WithMessage("وارد کردن اسم منبع الزامی است");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}