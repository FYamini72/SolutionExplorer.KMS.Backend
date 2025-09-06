using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.AAA.Validators
{
    public class UserRoleSearchDtoValidator : AbstractValidator<UserRoleSearchDto>
    {
        public UserRoleSearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UserRoleSearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}