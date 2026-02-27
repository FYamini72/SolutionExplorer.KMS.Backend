using SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Handlers
{
    public class GetQualityControlBaseInfoQueryHandler : IRequestHandler<GetQualityControlBaseInfoQuery, HandlerResponse<QualityControlBaseInfoDisplayDto>>
    {
        private readonly IBaseService<QualityControlBaseInfo> _service;

        public GetQualityControlBaseInfoQueryHandler(IBaseService<QualityControlBaseInfo> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<QualityControlBaseInfoDisplayDto>> Handle(GetQualityControlBaseInfoQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x=>x.StorageConditions)
                .Include(x=>x.QCBaseInfoExpectedResults)
                .Include(x=>x.QCBaseInfoPhysicalSpecifications)
                .Include(x=>x.PeriodicQCBaseInfoExpectedResults)
                .Include(x=>x.QCBaseInfoAppearances)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<QualityControlBaseInfoDisplayDto>();
        }
    }
}