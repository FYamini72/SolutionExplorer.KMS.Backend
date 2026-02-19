using FluentValidation;
using FluentValidation.Results;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class PersonnelColorBlindnessTestCreateDtoValidator : AbstractValidator<PersonnelColorBlindnessTestCreateDto>
    {
        public PersonnelColorBlindnessTestCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PersonnelColorBlindnessTestCreateDto> context, CancellationToken cancellation = default)
        {
            var _userService = ServiceLocator.GetService<IBaseService<User>>();

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

            RuleFor(x => x.TestDate)
                .NotEmpty()
                .WithMessage("تاریخ انجام آزمایش الزامی است")
                .NotNull()
                .WithMessage("تاریخ انجام آزمایش الزامی است");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}