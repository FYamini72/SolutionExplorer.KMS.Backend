using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class QualityControlSearchDtoValidator : AbstractValidator<QualityControlSearchDto>
    {
        public QualityControlSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<QualityControlSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}