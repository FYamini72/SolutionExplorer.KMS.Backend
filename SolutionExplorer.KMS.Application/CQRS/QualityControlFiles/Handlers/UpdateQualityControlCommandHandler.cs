using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Handlers
{
    public class UpdateQualityControlCommandHandler : IRequestHandler<UpdateQualityControlCommand, HandlerResponse<QualityControlDisplayDto>>
    {
        private readonly IBaseService<QualityControl> _service;

        public UpdateQualityControlCommandHandler(IBaseService<QualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<QualityControlDisplayDto>> Handle(UpdateQualityControlCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .Include(x => x.PerformedByUser)
                .Include(x => x.StorageCondition)
                .FirstOrDefaultAsync(x => x.Id == request.QualityControl.Id);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.QualityControl.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<QualityControlDisplayDto>();
        }
    }
}
