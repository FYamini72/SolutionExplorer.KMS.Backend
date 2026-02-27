using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Handlers
{
    public class CreatePeriodicQualityControlCommandHandler : IRequestHandler<CreatePeriodicQualityControlCommand, HandlerResponse<PeriodicQualityControlDisplayDto>>
    {
        private readonly IBaseService<PeriodicQualityControl> _service;

        public CreatePeriodicQualityControlCommandHandler(IBaseService<PeriodicQualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<PeriodicQualityControlDisplayDto>> Handle(CreatePeriodicQualityControlCommand request, CancellationToken cancellationToken)
        {
            var PeriodicQualityControl = request.PeriodicQualityControl.Adapt<PeriodicQualityControl>();

            var result = await _service.AddAsync(PeriodicQualityControl, cancellationToken);

            var obj = await _service
                .GetAll(x => x.Id == result.Id)
                .Include(x => x.PerformedByUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(cancellationToken);

            return obj.Adapt<PeriodicQualityControlDisplayDto>();
        }
    }
}
