using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Commands
{
    public class CreateLabReportHistoryCommand : IRequest<HandlerResponse<LabReportHistoryDisplayDto>>
    {
        public LabReportHistoryCreateDto LabReportHistory { get; }

        public CreateLabReportHistoryCommand(LabReportHistoryCreateDto LabReportHistory)
        {
            this.LabReportHistory = LabReportHistory;
        }
    }
}