using MediatR;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Queries
{
    public class GetAllUserRolesQuery : IRequest<HandlerResponse<BaseGridDto<UserRoleDisplayDto>>>
    {
        public UserRoleSearchDto? SearchDto { get; }

        public GetAllUserRolesQuery(UserRoleSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}