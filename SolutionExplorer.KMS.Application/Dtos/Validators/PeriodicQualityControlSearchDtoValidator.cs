using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class PeriodicQualityControlSearchDtoValidator : AbstractValidator<PeriodicQualityControlSearchDto>
    {
        public PeriodicQualityControlSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PeriodicQualityControlSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}