using SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Queries;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Handlers
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, HandlerResponse<RoleDisplayDto>>
    {
        private readonly IBaseService<Role> _service;

        public GetRoleQueryHandler(IBaseService<Role> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<RoleDisplayDto>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var obj = await _service.GetByIdAsync(cancellationToken, request.Id);

            if (obj == null)
                return new(false, "رکورد موردنظر یافت نشد", null);

            return obj.Adapt<RoleDisplayDto>();
        }
    }
}