using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Commands
{
    public class DeleteRoleCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteRoleCommand(int id)
        {
            Id = id;
        }
    }
}