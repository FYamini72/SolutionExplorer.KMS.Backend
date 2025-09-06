using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Commands
{
    public class CreateRoleCommand : IRequest<HandlerResponse<RoleDisplayDto>>
    {
        public RoleCreateDto Role { get; }

        public CreateRoleCommand(RoleCreateDto Role)
        {
            this.Role = Role;
        }
    }
}