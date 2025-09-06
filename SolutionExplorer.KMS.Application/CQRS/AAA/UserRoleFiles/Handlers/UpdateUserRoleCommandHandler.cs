using SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Handlers
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, HandlerResponse<UserRoleDisplayDto>>
    {
        private readonly IBaseService<UserRole> _service;

        public UpdateUserRoleCommandHandler(IBaseService<UserRole> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<UserRoleDisplayDto>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.UserRole.Id);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            request.UserRole.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            return result.Adapt<UserRoleDisplayDto>();
        }
    }
}
