using FluentValidation;
using FluentValidation.Results;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class PersonnelUpdateDtoValidator : AbstractValidator<PersonnelUpdateDto>
    {
        public PersonnelUpdateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PersonnelUpdateDto> context, CancellationToken cancellation = default)
        {
            var _userService = ServiceLocator.GetService<IBaseService<User>>();
            var _roleService = ServiceLocator.GetService<IBaseService<Role>>();

            RuleFor(x => x.RePassword)
                .NotEmpty()
                .WithMessage("در صورت وارد کردن کلمه عبور، تکرار آن الزامی است.")
                .Equal(x => x.Password)
                .WithMessage("کلمه عبور و تکرار آن با یکدیگر مطابقت ندارند.")
                .When(x => !string.IsNullOrWhiteSpace(x.Password));

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("وارد کردن نام الزامی است.")
                .NotNull()
                .WithMessage("وارد کردن نام الزامی است.")
                ;

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("وارد کردن نام خانوادگی الزامی است.")
                .NotNull()
                .WithMessage("وارد کردن نام خانوادگی الزامی است.")
                ;

            RuleFor(x => x.RoleIds)
                .NotNull()
                .WithMessage("انتخاب حداقل یک نقش الزامی است.")
                .NotEmpty()
                .WithMessage("انتخاب حداقل یک نقش الزامی است.")
                .Must(roleIds =>
                {
                    var count = _roleService
                        .GetAll(x => roleIds.Contains(x.Id))
                        .Count();

                    return count == roleIds.Count;
                })
                .WithMessage("نقش انتخاب شده معتبر نمی‌باشد.")
                ;

            RuleFor(x => x.Prefix)
                .NotNull()
                .WithMessage("وارد کردن پیشوند الزامی است.")
                .IsInEnum()
                .WithMessage("پیشوند انتخاب شده معتبر نمی‌باشد.")
                ;

            RuleFor(x => x.Gender)
                .NotNull()
                .WithMessage("وارد کردن جنسیت الزامی است.")
                .IsInEnum()
                .WithMessage("جنسیت انتخاب شده معتبر نمی‌باشد.")
                ;

            RuleFor(x => x.Position)
                .NotNull()
                .WithMessage("وارد کردن سمت و مقام الزامی است.")
                .IsInEnum()
                .WithMessage("سمت و مقام انتخاب شده معتبر نمی‌باشد.")
                ;

            RuleFor(x => x.EducationalDegree)
                .NotNull()
                .WithMessage("وارد کردن مدرک تحصیلی الزامی است.")
                .IsInEnum()
                .WithMessage("مدرک تحصیلی انتخاب شده معتبر نمی‌باشد.")
                ;

            RuleFor(x => x.EducationalField)
                .NotEmpty()
                .WithMessage("وارد کردن رشته تحصیلی الزامی است.")
                .NotNull()
                .WithMessage("وارد کردن رشته تحصیلی الزامی است.")
                ;

            RuleFor(x => x.OrganizationalChart)
                .NotEmpty()
                .WithMessage("وارد کردن چارت سازمانی الزامی است.")
                .NotNull()
                .WithMessage("وارد کردن چارت سازمانی الزامی است.")
                ;

            RuleFor(x => x.FirstConfirmerUserId)
                .NotNull()
                .WithMessage("انتخاب کاربر تاییدکننده الزامی است.")
                .Must(userId =>
                {
                    return _userService
                        .GetAll(x => x.Id == userId)
                        .Any();
                })
                .WithMessage("کاربر تاییدکننده انتخاب شده معتبر نمی‌باشد.")
                ;

            RuleFor(x => x.SecondConfirmerUserId)
                .NotNull()
                .WithMessage("انتخاب کاربر تصدیق‌کننده الزامی است.")
                .Must(userId =>
                {
                    return _userService
                        .GetAll(x => x.Id == userId)
                        .Any();
                })
                .WithMessage("کاربر تصدیق‌کننده انتخاب شده معتبر نمی‌باشد.")
                ;

            RuleFor(x => x.SuccessorUserId)
                .Must(userId =>
                {
                    if (!userId.HasValue)
                        return true;

                    return _userService
                        .GetAll(x => x.Id == userId.Value)
                        .Any();
                })
                .WithMessage("جانشین انتخاب شده معتبر نمی‌باشد.")
                ;

            return await base.ValidateAsync(context, cancellation);
        }
    }
}