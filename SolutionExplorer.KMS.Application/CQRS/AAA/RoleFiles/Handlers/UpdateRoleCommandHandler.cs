using SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Handlers
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, HandlerResponse<RoleDisplayDto>>
    {
        private readonly IBaseService<Role> _service;

        public UpdateRoleCommandHandler(IBaseService<Role> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<RoleDisplayDto>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Role.Id);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.Role.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<RoleDisplayDto>();
        }
    }
}
