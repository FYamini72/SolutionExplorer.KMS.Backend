using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Handlers
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, HandlerResponse<EquipmentDisplayDto>>
    {
        private readonly IBaseService<Equipment> _service;

        public UpdateEquipmentCommandHandler(IBaseService<Equipment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<EquipmentDisplayDto>> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Equipment.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.Equipment.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<EquipmentDisplayDto>();
        }
    }
}
