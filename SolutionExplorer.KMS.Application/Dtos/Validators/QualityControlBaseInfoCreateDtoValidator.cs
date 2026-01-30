using FluentValidation;
using FluentValidation.Results;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class QualityControlBaseInfoCreateDtoValidator : AbstractValidator<QualityControlBaseInfoCreateDto>
    {
        public QualityControlBaseInfoCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<QualityControlBaseInfoCreateDto> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("وارد کردن عنوان الزامی است")
                .NotNull()
                .WithMessage("وارد کردن عنوان الزامی است");

            //RuleFor(x => x.Manufacturer)
            //    .NotEmpty()
            //    .WithMessage("وارد کردن سازنده الزامی است")
            //    .NotNull()
            //    .WithMessage("وارد کردن سازنده الزامی است");

            //RuleFor(x => x.Series)
            //    .NotEmpty()
            //    .WithMessage("وارد کردن سری ساخت الزامی است")
            //    .NotNull()
            //    .WithMessage("وارد کردن سری ساخت الزامی است");

            //RuleFor(x => x.ProductionDate)
            //    .NotEmpty()
            //    .WithMessage("تاریخ تولید الزامی است")
            //    .NotNull()
            //    .WithMessage("تاریخ تولید الزامی است");

            //RuleFor(x => x.ExpirationDate)
            //    .NotEmpty()
            //    .WithMessage("تاریخ انقضا الزامی است")
            //    .NotNull()
            //    .WithMessage("تاریخ انقضا الزامی است");

            RuleFor(x => x.NextQualityControlTime)
                .NotEmpty()
                .WithMessage("انتخاب تاریخ کنترل کیفی بعدی الزامی است")
                .NotNull()
                .WithMessage("انتخاب تاریخ کنترل کیفی بعدی الزامی است");

            RuleFor(x => x.DayIntervalCount)
                .NotNull()
                .WithMessage("در حالت دوره‌ای مقدار «هر چند روز؟» الزامی است")
                .GreaterThan(0)
                .WithMessage("مقدار «هر چند روز؟» باید بزرگتر از صفر باشد")
                .When(x => x.QualityControlPeriod == QualityControlPeriod.Periodic);

            return await base.ValidateAsync(context, cancellation);
        }
    }
}