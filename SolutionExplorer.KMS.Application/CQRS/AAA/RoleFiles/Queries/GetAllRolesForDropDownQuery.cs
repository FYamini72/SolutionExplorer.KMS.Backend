using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Queries
{
    public class GetAllRolesForDropDownQuery : IRequest<HandlerResponse<List<KeyValuePair<int, string>>>>
    {
        public RoleSearchDto? SearchDto { get; }

        public GetAllRolesForDropDownQuery(RoleSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}