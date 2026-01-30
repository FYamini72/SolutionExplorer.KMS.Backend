using SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Handlers
{
    public class UpdateQualityControlBaseInfoCommandHandler : IRequestHandler<UpdateQualityControlBaseInfoCommand, HandlerResponse<QualityControlBaseInfoDisplayDto>>
    {
        private readonly IBaseService<QualityControlBaseInfo> _service;

        public UpdateQualityControlBaseInfoCommandHandler(IBaseService<QualityControlBaseInfo> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<QualityControlBaseInfoDisplayDto>> Handle(UpdateQualityControlBaseInfoCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.QualityControlBaseInfo.Id);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.QualityControlBaseInfo.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<QualityControlBaseInfoDisplayDto>();
        }
    }
}
