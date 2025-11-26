using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Handlers
{
    public class UpdateLabReportHistoryCommandHandler : IRequestHandler<UpdateLabReportHistoryCommand, HandlerResponse<LabReportHistoryDisplayDto>>
    {
        private readonly IBaseService<LabReportHistory> _service;

        public UpdateLabReportHistoryCommandHandler(IBaseService<LabReportHistory> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<LabReportHistoryDisplayDto>> Handle(UpdateLabReportHistoryCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.ReporterUser)
                .Include(x => x.ReceiverUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.LabReportHistory.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.LabReportHistory.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<LabReportHistoryDisplayDto>();
        }
    }
}
