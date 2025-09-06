using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Commands
{
    public class DeleteUserRoleCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeleteUserRoleCommand(int id)
        {
            Id = id;
        }
    }
}