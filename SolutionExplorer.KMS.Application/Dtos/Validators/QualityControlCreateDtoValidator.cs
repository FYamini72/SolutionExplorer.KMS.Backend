using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class QualityControlCreateDtoValidator : AbstractValidator<QualityControlCreateDto>
    {
        public QualityControlCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<QualityControlCreateDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}