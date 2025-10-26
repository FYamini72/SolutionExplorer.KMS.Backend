using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Queries
{
    public class GetAllLabReportHistoriesQuery : IRequest<HandlerResponse<BaseGridDto<LabReportHistoryDisplayDto>>>
    {
        public LabReportHistorySearchDto? SearchDto { get; }

        public GetAllLabReportHistoriesQuery(LabReportHistorySearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}