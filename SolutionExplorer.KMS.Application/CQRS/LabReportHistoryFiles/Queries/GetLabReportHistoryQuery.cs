using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Queries
{
    public class GetLabReportHistoryQuery : IRequest<HandlerResponse<LabReportHistoryDisplayDto>>
    {
        public int Id { get; }

        public GetLabReportHistoryQuery(int id)
        {
            Id = id;
        }
    }
}