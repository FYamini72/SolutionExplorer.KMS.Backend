using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class EquipmentSearchDtoValidator : AbstractValidator<EquipmentSearchDto>
    {
        public EquipmentSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<EquipmentSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}