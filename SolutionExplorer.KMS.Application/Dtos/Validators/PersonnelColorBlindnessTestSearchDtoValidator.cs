using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class PersonnelColorBlindnessTestSearchDtoValidator : AbstractValidator<PersonnelColorBlindnessTestSearchDto>
    {
        public PersonnelColorBlindnessTestSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PersonnelColorBlindnessTestSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}