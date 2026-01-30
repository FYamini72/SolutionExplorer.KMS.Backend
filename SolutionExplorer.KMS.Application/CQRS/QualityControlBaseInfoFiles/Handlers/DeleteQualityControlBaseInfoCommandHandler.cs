using SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Handlers
{
    public class DeleteQualityControlBaseInfoCommandHandler : IRequestHandler<DeleteQualityControlBaseInfoCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<QualityControlBaseInfo> _service;

        public DeleteQualityControlBaseInfoCommandHandler(IBaseService<QualityControlBaseInfo> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteQualityControlBaseInfoCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
