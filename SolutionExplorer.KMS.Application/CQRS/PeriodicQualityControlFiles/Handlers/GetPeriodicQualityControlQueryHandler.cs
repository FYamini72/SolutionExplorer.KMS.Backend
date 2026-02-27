using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Handlers
{
    public class GetPeriodicQualityControlQueryHandler : IRequestHandler<GetPeriodicQualityControlQuery, HandlerResponse<PeriodicQualityControlDisplayDto>>
    {
        private readonly IBaseService<PeriodicQualityControl> _service;

        public GetPeriodicQualityControlQueryHandler(IBaseService<PeriodicQualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PeriodicQualityControlDisplayDto>> Handle(GetPeriodicQualityControlQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll(x => x.Id == request.Id)
                .Include(x => x.PerformedByUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(cancellationToken);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<PeriodicQualityControlDisplayDto>();
        }
    }
}