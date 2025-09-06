using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Commands
{
    public class CreateUserRoleCommand : IRequest<HandlerResponse<UserRoleDisplayDto>>
    {
        public UserRoleCreateDto UserRole { get; }

        public CreateUserRoleCommand(UserRoleCreateDto UserRole)
        {
            this.UserRole = UserRole;
        }
    }
}