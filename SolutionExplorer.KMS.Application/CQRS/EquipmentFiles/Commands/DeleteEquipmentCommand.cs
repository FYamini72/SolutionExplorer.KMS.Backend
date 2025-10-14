using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Commands
{
    public class DeleteEquipmentCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteEquipmentCommand(int id)
        {
            Id = id;
        }
    }
}