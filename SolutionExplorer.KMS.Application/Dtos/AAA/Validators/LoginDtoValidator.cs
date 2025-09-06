using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.AAA.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<LoginDto> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("وارد کردن نام کاربری الزامی است")
                .NotNull()
                .WithMessage("وارد کردن نام کاربری الزامی است");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("وارد کردن کلمه عبور الزامی است")
                .NotNull()
                .WithMessage("وارد کردن کلمه عبور الزامی است");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}