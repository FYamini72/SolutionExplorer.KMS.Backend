using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class QualityControlBaseInfoSearchDtoValidator : AbstractValidator<QualityControlBaseInfoSearchDto>
    {
        public QualityControlBaseInfoSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<QualityControlBaseInfoSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}