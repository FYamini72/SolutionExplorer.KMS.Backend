using SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Commands;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Handlers
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, HandlerResponse<bool>>
    {
        private readonly IBaseService<UserRole> _service;

        public DeleteUserRoleCommandHandler(IBaseService<UserRole> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", false);

            await _service.DeleteAsync(obj, cancellationToken);
            return true;
        }
    }
}
