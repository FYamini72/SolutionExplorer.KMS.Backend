using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Commands
{
    public class DeletePersonnelCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeletePersonnelCommand(int id)
        {
            Id = id;
        }
    }
}