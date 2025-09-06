using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Commands
{
    public class UpdateUserRoleCommand : IRequest<HandlerResponse<UserRoleDisplayDto>>
    {
        public UserRoleCreateDto UserRole { get; }

        public UpdateUserRoleCommand(UserRoleCreateDto UserRole)
        {
            this.UserRole = UserRole;
        }
    }
}