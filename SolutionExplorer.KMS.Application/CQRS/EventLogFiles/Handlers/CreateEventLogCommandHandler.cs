using Mapster;
using MediatR;
using SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Handlers
{
    public class CreateEventLogCommandHandler : IRequestHandler<CreateEventLogCommand, HandlerResponse<EventLogDisplayDto>>
    {
        private readonly IBaseService<EventLog> _service;

        public CreateEventLogCommandHandler(IBaseService<EventLog> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<EventLogDisplayDto>> Handle(CreateEventLogCommand request, CancellationToken cancellationToken)
        {
            var eventLog = request.EventLog.Adapt<EventLog>();

            var result = await _service.AddAsync(eventLog, cancellationToken);
            return result.Adapt<EventLogDisplayDto>();
        }
    }
}
