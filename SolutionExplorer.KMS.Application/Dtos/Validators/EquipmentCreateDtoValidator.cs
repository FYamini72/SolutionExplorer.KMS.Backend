using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class EquipmentCreateDtoValidator : AbstractValidator<EquipmentCreateDto>
    {
        public EquipmentCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<EquipmentCreateDto> context, CancellationToken cancellation = default)
        {
            var _userService = ServiceLocator.GetService<IBaseService<User>>();
            var _identifierService = ServiceLocator.GetService<IBaseService<Identifier>>();

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("وارد کردن نام دستگاه الزامی است")
                .NotNull()
                .WithMessage("وارد کردن نام دستگاه الزامی است");

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("وارد کردن کد دستگاه الزامی است")
                .NotNull()
                .WithMessage("وارد کردن کد دستگاه الزامی است");

            //RuleFor(x => x.EquipmentModel)
            //    .NotEmpty()
            //    .WithMessage("وارد کردن مدل الزامی است")
            //    .NotNull()
            //    .WithMessage("وارد کردن مدل الزامی است");

            RuleFor(x => x.SerialNo)
                .NotEmpty()
                .WithMessage("وارد کردن شماره سریال الزامی است")
                .NotNull()
                .WithMessage("وارد کردن شماره سریال الزامی است");

            //RuleFor(x => x.Manufacturer)
            //    .NotEmpty()
            //    .WithMessage("وارد کردن سازنده الزامی است")
            //    .NotNull()
            //    .WithMessage("وارد کردن سازنده الزامی است");

            //RuleFor(x => x.ManufactureCountry)
            //    .NotEmpty()
            //    .WithMessage("وارد کردن کشور سازنده الزامی است")
            //    .NotNull()
            //    .WithMessage("وارد کردن کشور سازنده الزامی است");

            RuleFor(x => x.IdentifierId)
                .NotEmpty()
                .WithMessage("انتخاب کردن شناسنامه الزامی است")
                .NotNull()
                .WithMessage("انتخاب کردن شناسنامه الزامی است")
                .MustAsync(async (identifierId, cancellationToken) =>
                {
                    if (!identifierId.HasValue)
                        return true;
                    return await _identifierService.GetAll(x => x.Id == identifierId).AnyAsync();
                })
                .WithMessage("شناسنامه انتخاب شده معتبر نیست");

            RuleFor(x => x.FirstConfirmerUserId)
                .NotEmpty()
                .WithMessage("انتخاب کردن تایید کننده الزامی است")
                .NotNull()
                .WithMessage("انتخاب کردن تایید کننده الزامی است")
                .MustAsync(async (firstConfirmerUserId, cancellationToken) =>
                {
                    if (!firstConfirmerUserId.HasValue)
                        return true;
                    return await _userService.GetAll(x => x.Id == firstConfirmerUserId).AnyAsync();
                })
                .WithMessage("تایید کننده انتخاب شده معتبر نیست");

            RuleFor(x => x.SecondConfirmerUserId)
                .NotEmpty()
                .WithMessage("انتخاب کردن تصدیق کننده الزامی است")
                .NotNull()
                .WithMessage("انتخاب کردن تصدیق کننده الزامی است")
                .MustAsync(async (secondConfirmerUserId, cancellationToken) =>
                {
                    if (!secondConfirmerUserId.HasValue)
                        return true;
                    return await _userService.GetAll(x => x.Id == secondConfirmerUserId).AnyAsync();
                })
                .WithMessage("تصدیق کننده انتخاب شده معتبر نیست");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}