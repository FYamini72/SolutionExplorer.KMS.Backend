using FluentValidation;
using FluentValidation.Results;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class PersonnelTrainingCourseCreateDtoValidator : AbstractValidator<PersonnelTrainingCourseCreateDto>
    {
        public PersonnelTrainingCourseCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PersonnelTrainingCourseCreateDto> context, CancellationToken cancellation = default)
        {
            var _userService = ServiceLocator.GetService<IBaseService<User>>();

            RuleFor(x => x.PersonnelId)
                .NotNull()
                .WithMessage("انتخاب پرسنل الزامی است.")
                .Must(userId =>
                {
                    return _userService
                        .GetAll(x => x.Id == userId)
                        .Any();
                })
                .WithMessage("پرسنل انتخاب شده معتبر نمی‌باشد.")
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

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("عنوان دوره الزامی است")
                .NotNull()
                .WithMessage("عنوان دوره الزامی است");

            RuleFor(x => x.Duration)
                .NotEmpty()
                .WithMessage("مدت دوره الزامی است")
                .NotNull()
                .WithMessage("مدت دوره الزامی است");

            RuleFor(x => x.TeacherFullName)
                .NotEmpty()
                .WithMessage("نام مدرس الزامی است")
                .NotNull()
                .WithMessage("نام مدرس الزامی است");

            RuleFor(x => x.QualificationCriteria)
                .NotEmpty()
                .WithMessage("نمره قبولی الزامی است")
                .NotNull()
                .WithMessage("نمره قبولی الزامی است")
                .Must(qualificationCriteria =>
                {
                    return (qualificationCriteria ?? 0) >= 60 && (qualificationCriteria ?? 0) <= 100;
                })
                .WithMessage("نمره قبولی باید بین 60 الی 100 باشد.");

            RuleFor(x => x.ScoreEarned)
                .Must(scoreEarned =>
                {
                    if (scoreEarned.HasValue)
                        return (scoreEarned ?? 0) >= 0 && (scoreEarned ?? 0) <= 100;
                    else 
                        return true;
                })
                .WithMessage("نمره کسب شده باید بین 0 الی 100 باشد.");

            RuleFor(x => x.IsConfirmed)
                .NotEmpty()
                .WithMessage("وضعیت قبولی الزامی است")
                .NotNull()
                .WithMessage("وضعیت قبولی الزامی است");

            RuleFor(x => x.DateOfEvent)
                .NotEmpty()
                .WithMessage("تاریخ برگزاری الزامی است")
                .NotNull()
                .WithMessage("تاریخ برگزاری الزامی است");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}