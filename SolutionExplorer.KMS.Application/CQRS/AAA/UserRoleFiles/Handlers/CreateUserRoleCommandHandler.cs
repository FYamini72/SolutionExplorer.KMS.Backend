using SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Handlers
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, HandlerResponse<UserRoleDisplayDto>>
    {
        private readonly IBaseService<UserRole> _service;

        public CreateUserRoleCommandHandler(IBaseService<UserRole> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<UserRoleDisplayDto>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var UserRole = request.UserRole.Adapt<UserRole>();

            var result = await _service.AddAsync(UserRole, cancellationToken);
            return result.Adapt<UserRoleDisplayDto>();
        }
    }
}
