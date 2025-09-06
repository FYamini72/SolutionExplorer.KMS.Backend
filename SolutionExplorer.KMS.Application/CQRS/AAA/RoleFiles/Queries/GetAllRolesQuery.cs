using MediatR;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Queries
{
    public class GetAllRolesQuery : IRequest<HandlerResponse<BaseGridDto<RoleDisplayDto>>>
    {
        public RoleSearchDto? SearchDto { get; }

        public GetAllRolesQuery(RoleSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}