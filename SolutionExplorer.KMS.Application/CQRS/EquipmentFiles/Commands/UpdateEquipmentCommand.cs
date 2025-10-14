using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Commands
{
    public class UpdateEquipmentCommand : IRequest<HandlerResponse<EquipmentDisplayDto>>
    {
        public EquipmentCreateDto Equipment { get; }

        public UpdateEquipmentCommand(EquipmentCreateDto Equipment)
        {
            this.Equipment = Equipment;
        }
    }
}