using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Queries
{
    public class GetEventLogQuery : IRequest<HandlerResponse<EventLogDisplayDto>>
    {
        public int Id { get; }

        public GetEventLogQuery(int id)
        {
            Id = id;
        }
    }
}