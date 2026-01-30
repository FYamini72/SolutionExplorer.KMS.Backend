using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class StorageConditionSearchDtoValidator : AbstractValidator<StorageConditionSearchDto>
    {
        public StorageConditionSearchDtoValidator()
        {
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<StorageConditionSearchDto> context, CancellationToken cancellation = default)
        {
            return base.ValidateAsync(context, cancellation);
        }
    }
}