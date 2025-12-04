using SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Handlers
{
    public class CreateQualityControlBaseInfoCommandHandler : IRequestHandler<CreateQualityControlBaseInfoCommand, HandlerResponse<QualityControlBaseInfoDisplayDto>>
    {
        private readonly IBaseService<QualityControlBaseInfo> _service;

        public CreateQualityControlBaseInfoCommandHandler(IBaseService<QualityControlBaseInfo> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<QualityControlBaseInfoDisplayDto>> Handle(CreateQualityControlBaseInfoCommand request, CancellationToken cancellationToken)
        {
            var QualityControlBaseInfo = request.QualityControlBaseInfo.Adapt<QualityControlBaseInfo>();

            var result = await _service.AddAsync(QualityControlBaseInfo, cancellationToken);
            return result.Adapt<QualityControlBaseInfoDisplayDto>();
        }
    }
}
