using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Handlers
{
    public class GetQualityControlQueryHandler : IRequestHandler<GetQualityControlQuery, HandlerResponse<QualityControlDisplayDto>>
    {
        private readonly IBaseService<QualityControl> _service;

        public GetQualityControlQueryHandler(IBaseService<QualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<QualityControlDisplayDto>> Handle(GetQualityControlQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .Include(x => x.PerformedByUser)
                .Include(x => x.StorageCondition)
                .Include(x => x.PhysicalSpecifications)
                    .ThenInclude(x=>x.QCBaseInfoPhysicalSpecification)
                .FirstOrDefaultAsync(x=>x.Id == request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<QualityControlDisplayDto>();
        }
    }
}