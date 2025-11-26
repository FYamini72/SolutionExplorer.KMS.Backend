using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class IdentifierCreateDtoValidator : AbstractValidator<IdentifierCreateDto>
    {
        public IdentifierCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<IdentifierCreateDto> context, CancellationToken cancellation = default)
        {
            var _userService = ServiceLocator.GetService<IBaseService<User>>();

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("وارد کردن اسم سند الزامی است")
                .NotNull()
                .WithMessage("وارد کردن اسم سند الزامی است");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .WithMessage("وارد کردن شماره سند الزامی است")
                .NotNull()
                .WithMessage("وارد کردن شماره سند الزامی است");

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("وارد کردن دسته یندی سند الزامی است")
                .NotNull()
                .WithMessage("وارد کردن دسته یندی سند الزامی است");

            RuleFor(x => x.EditNo)
                .NotEmpty()
                .WithMessage("وارد کردن شماره ویرایش الزامی است")
                .NotNull()
                .WithMessage("وارد کردن شماره ویرایش الزامی است");

            RuleFor(x => x.ProducerUserId)
                .NotEmpty()
                .WithMessage("انتخاب کردن تهیه کننده الزامی است")
                .NotNull()
                .WithMessage("انتخاب کردن تهیه کننده الزامی است")
                .MustAsync(async (producerUserId, cancellationToken) =>
                {
                    if (!producerUserId.HasValue)
                        return true;
                    return await _userService.GetAll(x => x.Id == producerUserId).AnyAsync();
                })
                .WithMessage("تهیه کننده انتخاب شده معتبر نیست");

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