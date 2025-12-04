using SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Handlers
{
    public class DeleteQualityControlCommandHandler : IRequestHandler<DeleteQualityControlCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<QualityControl> _service;

        public DeleteQualityControlCommandHandler(IBaseService<QualityControl> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteQualityControlCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
