using SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Handlers
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<Role> _service;

        public DeleteRoleCommandHandler(IBaseService<Role> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
