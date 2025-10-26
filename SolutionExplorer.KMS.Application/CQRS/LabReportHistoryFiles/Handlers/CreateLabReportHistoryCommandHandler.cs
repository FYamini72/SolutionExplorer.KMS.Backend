using SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Handlers
{
    public class CreateLabReportHistoryCommandHandler : IRequestHandler<CreateLabReportHistoryCommand, HandlerResponse<LabReportHistoryDisplayDto>>
    {
        private readonly IBaseService<LabReportHistory> _service;

        public CreateLabReportHistoryCommandHandler(IBaseService<LabReportHistory> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<LabReportHistoryDisplayDto>> Handle(CreateLabReportHistoryCommand request, CancellationToken cancellationToken)
        {
            var LabReportHistory = request.LabReportHistory.Adapt<LabReportHistory>();

            var result = await _service.AddAsync(LabReportHistory, cancellationToken);
            return result.Adapt<LabReportHistoryDisplayDto>();
        }
    }
}
