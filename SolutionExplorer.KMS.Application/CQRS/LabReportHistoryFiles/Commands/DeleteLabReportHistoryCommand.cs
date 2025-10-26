using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Commands
{
    public class DeleteLabReportHistoryCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteLabReportHistoryCommand(int id)
        {
            Id = id;
        }
    }
}