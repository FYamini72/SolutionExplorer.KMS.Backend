using SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Handlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, HandlerResponse<RoleDisplayDto>>
    {
        private readonly IBaseService<Role> _service;

        public CreateRoleCommandHandler(IBaseService<Role> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<RoleDisplayDto>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var Role = request.Role.Adapt<Role>();

            var result = await _service.AddAsync(Role, cancellationToken);
            return result.Adapt<RoleDisplayDto>();
        }
    }
}
