using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class PeriodicQualityControlCreateDtoValidator : AbstractValidator<PeriodicQualityControlCreateDto>
    {
        public PeriodicQualityControlCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PeriodicQualityControlCreateDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}