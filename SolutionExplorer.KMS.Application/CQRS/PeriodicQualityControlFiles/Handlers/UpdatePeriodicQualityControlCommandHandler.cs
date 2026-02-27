using SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Handlers
{
    public class UpdatePeriodicQualityControlCommandHandler : IRequestHandler<UpdatePeriodicQualityControlCommand, HandlerResponse<PeriodicQualityControlDisplayDto>>
    {
        private readonly IBaseService<PeriodicQualityControl> _service;

        public UpdatePeriodicQualityControlCommandHandler(IBaseService<PeriodicQualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PeriodicQualityControlDisplayDto>> Handle(UpdatePeriodicQualityControlCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll(x => x.Id == request.PeriodicQualityControl.Id)
                .Include(x => x.PerformedByUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.PeriodicQualityControl.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<PeriodicQualityControlDisplayDto>();
        }
    }
}
