using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Commands
{
    public class CreateEquipmentCommand : IRequest<HandlerResponse<EquipmentDisplayDto>>
    {
        public EquipmentCreateDto Equipment { get; }

        public CreateEquipmentCommand(EquipmentCreateDto Equipment)
        {
            this.Equipment = Equipment;
        }
    }
}