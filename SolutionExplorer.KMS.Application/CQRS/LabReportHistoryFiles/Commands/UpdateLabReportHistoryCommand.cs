using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Commands
{
    public class UpdateLabReportHistoryCommand : IRequest<HandlerResponse<LabReportHistoryDisplayDto>>
    {
        public LabReportHistoryCreateDto LabReportHistory { get; }

        public UpdateLabReportHistoryCommand(LabReportHistoryCreateDto LabReportHistory)
        {
            this.LabReportHistory = LabReportHistory;
        }
    }
}