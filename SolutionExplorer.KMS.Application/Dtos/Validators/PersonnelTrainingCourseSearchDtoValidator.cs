using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class PersonnelTrainingCourseSearchDtoValidator : AbstractValidator<PersonnelTrainingCourseSearchDto>
    {
        public PersonnelTrainingCourseSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<PersonnelTrainingCourseSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}