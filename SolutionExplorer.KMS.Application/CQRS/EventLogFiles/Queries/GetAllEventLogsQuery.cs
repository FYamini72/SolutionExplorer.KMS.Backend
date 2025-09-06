using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Queries
{
    public class GetAllEventLogsQuery : IRequest<HandlerResponse<BaseGridDto<EventLogDisplayDto>>>
    {
        public EventLogSearchDto? SearchDto { get; }

        public GetAllEventLogsQuery(EventLogSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}
