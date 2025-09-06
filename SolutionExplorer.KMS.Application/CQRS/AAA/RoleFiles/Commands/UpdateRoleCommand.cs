using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Commands
{
    public class UpdateRoleCommand : IRequest<HandlerResponse<RoleDisplayDto>>
    {
        public RoleCreateDto Role { get; }

        public UpdateRoleCommand(RoleCreateDto Role)
        {
            this.Role = Role;
        }
    }
}