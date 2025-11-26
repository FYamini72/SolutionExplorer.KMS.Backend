using SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Handlers
{
    public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Equipment> _service;

        public DeleteEquipmentCommandHandler(IBaseService<Equipment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
