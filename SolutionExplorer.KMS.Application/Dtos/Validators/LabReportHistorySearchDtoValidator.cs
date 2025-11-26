using FluentValidation;
using FluentValidation.Results;

namespace SolutionExplorer.KMS.Application.Dtos.Validators
{
    public class LabReportHistorySearchDtoValidator : AbstractValidator<LabReportHistorySearchDto>
    {
        public LabReportHistorySearchDtoValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<LabReportHistorySearchDto> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}