using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class IdentifierSearchDtoValidator : AbstractValidator<IdentifierSearchDto>
    {
        public IdentifierSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<IdentifierSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}