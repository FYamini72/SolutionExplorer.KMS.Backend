using Mapster;
using MediatR;
using SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.EventLogFiles.Handlers
{
    public class GetEventLogQueryHandler : IRequestHandler<GetEventLogQuery, HandlerResponse<EventLogDisplayDto>>
    {
        private readonly IBaseService<EventLog> _service;

        public GetEventLogQueryHandler(IBaseService<EventLog> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<EventLogDisplayDto>> Handle(GetEventLogQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<EventLogDisplayDto>();
        }
    }
}
