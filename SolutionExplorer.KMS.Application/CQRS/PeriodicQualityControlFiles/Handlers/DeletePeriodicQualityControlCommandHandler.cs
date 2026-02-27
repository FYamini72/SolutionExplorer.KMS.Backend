using SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Handlers
{
    public class DeletePeriodicQualityControlCommandHandler : IRequestHandler<DeletePeriodicQualityControlCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<PeriodicQualityControl> _service;

        public DeletePeriodicQualityControlCommandHandler(IBaseService<PeriodicQualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeletePeriodicQualityControlCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
