using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.AAA.Validators
{
    public class RoleCreateDtoValidator : AbstractValidator<RoleCreateDto>
    {
        public RoleCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<RoleCreateDto> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("وارد کردن نام نقش الزامی است")
                .NotNull()
                .WithMessage("وارد کردن نام نقش الزامی است");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}