using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.AAA.Validators
{
    public class UserRoleCreateDtoValidator : AbstractValidator<UserRoleCreateDto>
    {
        public UserRoleCreateDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UserRoleCreateDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}