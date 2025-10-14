using SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Handlers
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, HandlerResponse<EquipmentDisplayDto>>
    {
        private readonly IBaseService<Equipment> _service;

        public CreateEquipmentCommandHandler(IBaseService<Equipment> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<EquipmentDisplayDto>> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var Equipment = request.Equipment.Adapt<Equipment>();

            var result = await _service.AddAsync(Equipment, cancellationToken);
            return result.Adapt<EquipmentDisplayDto>();
        }
    }
}
