using SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Handlers
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, HandlerResponse<UserRoleDisplayDto>>
    {
        private readonly IBaseService<UserRole> _service;

        public GetUserRoleQueryHandler(IBaseService<UserRole> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<UserRoleDisplayDto>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<UserRoleDisplayDto>();
        }
    }
}