using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class LabReportHistoryCreateDtoValidator : AbstractValidator<LabReportHistoryCreateDto>
    {
        public LabReportHistoryCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<LabReportHistoryCreateDto> context, CancellationToken cancellation = default)
        {
            var _userService = ServiceLocator.GetService<IBaseService<User>>();

            // --- تاریخ گزارش ---
            RuleFor(x => x.ReportDateTime)
                .NotEmpty()
                .WithMessage("تاریخ و ساعت ثبت گزارش الزامی است")
                .NotNull()
                .WithMessage("تاریخ و ساعت ثبت گزارش الزامی است");

            // --- گزارش‌دهنده ---
            RuleFor(x => x.ReporterUserId)
                .NotEmpty()
                .WithMessage("انتخاب گزارش‌دهنده الزامی است")
                .NotNull()
                .WithMessage("انتخاب گزارش‌دهنده الزامی است")
                .MustAsync(async (reporterUserId, cancellationToken) =>
                {
                    return await _userService.GetAll(x => x.Id == reporterUserId).AnyAsync();
                })
                .WithMessage("گزارش‌دهنده انتخاب‌شده معتبر نیست");

            // --- گزارش‌گیرنده ---
            RuleFor(x => x.ReceiverUserId)
                .MustAsync(async (receiverUserId, cancellationToken) =>
                {
                    if (!receiverUserId.HasValue)
                        return true;
                    return await _userService.GetAll(x => x.Id == receiverUserId).AnyAsync();
                })
                .WithMessage("گزارش‌گیرنده انتخاب‌شده معتبر نیست");

            // --- نام بیمار ---
            RuleFor(x => x.PatientName)
                .NotEmpty()
                .WithMessage("نام بیمار الزامی است")
                .NotNull()
                .WithMessage("نام بیمار الزامی است")
                .MaximumLength(100)
                .WithMessage("نام بیمار نمی‌تواند بیش از 100 کاراکتر باشد");

            // --- شماره پذیرش ---
            RuleFor(x => x.AdmissionNumber)
                .NotEmpty()
                .WithMessage("شماره پذیرش الزامی است")
                .NotNull()
                .WithMessage("شماره پذیرش الزامی است")
                .MaximumLength(50)
                .WithMessage("شماره پذیرش نمی‌تواند بیش از 50 کاراکتر باشد");

            // --- شرح بحرانی ---
            When(x => x.IsCritical, () =>
            {
                RuleFor(x => x.Description)
                    .NotEmpty()
                    .WithMessage("در صورت بحرانی بودن، وارد کردن توضیحات الزامی است")
                    .NotNull()
                    .WithMessage("در صورت بحرانی بودن، وارد کردن توضیحات الزامی است")
                    .MaximumLength(1500)
                    .WithMessage("توضیحات نمی‌تواند بیش از 1500 کاراکتر باشد");
            });

            // --- تاییدکننده ---
            RuleFor(x => x.FirstConfirmerUserId)
                .NotEmpty()
                .WithMessage("انتخاب تاییدکننده الزامی است")
                .NotNull()
                .WithMessage("انتخاب تاییدکننده الزامی است")
                .MustAsync(async (firstConfirmerUserId, cancellationToken) =>
                {
                    return await _userService.GetAll(x => x.Id == firstConfirmerUserId).AnyAsync();
                })
                .WithMessage("تاییدکننده انتخاب‌شده معتبر نیست");

            // --- تصدیق‌کننده ---
            RuleFor(x => x.SecondConfirmerUserId)
                .NotEmpty()
                .WithMessage("انتخاب تصدیق‌کننده الزامی است")
                .NotNull()
                .WithMessage("انتخاب تصدیق‌کننده الزامی است")
                .MustAsync(async (secondConfirmerUserId, cancellationToken) =>
                {
                    return await _userService.GetAll(x => x.Id == secondConfirmerUserId).AnyAsync();
                })
                .WithMessage("تصدیق‌کننده انتخاب‌شده معتبر نیست");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}