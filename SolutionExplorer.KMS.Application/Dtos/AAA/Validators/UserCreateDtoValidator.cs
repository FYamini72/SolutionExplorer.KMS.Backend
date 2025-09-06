using FluentValidation;
using FluentValidation.Results;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Dtos.AAA.Validators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UserCreateDto> context, CancellationToken cancellation = default)
        {
            var _userService = ServiceLocator.GetService<IBaseService<User>>();

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("وارد کردن نام کاربری الزامی است")
                .NotNull()
                .WithMessage("وارد کردن نام کاربری الزامی است")
                .Must((obj, username) =>
                {
                    return !_userService.GetAll(x => x.Id != obj.Id && x.UserName == username).Any();
                })
                .WithMessage("نام کاربری وارد شده تکراری می باشد")
                ;

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("وارد کردن کلمه عبور الزامی است")
                .NotNull()
                .WithMessage("وارد کردن کلمه عبور الزامی است");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}