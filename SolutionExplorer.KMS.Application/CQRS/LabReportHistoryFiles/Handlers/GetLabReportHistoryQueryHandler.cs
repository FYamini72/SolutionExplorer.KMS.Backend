using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.LabReportHistoryFiles.Handlers
{
    public class GetLabReportHistoryQueryHandler : IRequestHandler<GetLabReportHistoryQuery, HandlerResponse<LabReportHistoryDisplayDto>>
    {
        private readonly IBaseService<LabReportHistory> _service;

        public GetLabReportHistoryQueryHandler(IBaseService<LabReportHistory> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<LabReportHistoryDisplayDto>> Handle(GetLabReportHistoryQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.ReporterUser)
                .Include(x => x.ReceiverUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            return obj.Adapt<LabReportHistoryDisplayDto>();
        }
    }
}