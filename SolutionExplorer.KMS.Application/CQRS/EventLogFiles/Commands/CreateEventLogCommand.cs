using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Commands
{
    public class CreateEventLogCommand : IRequest<HandlerResponse<EventLogDisplayDto>>
    {
        public EventLogCreateDto EventLog { get; }

        public CreateEventLogCommand(EventLogCreateDto Content)
        {
            this.EventLog = Content;
        }
    }
}
