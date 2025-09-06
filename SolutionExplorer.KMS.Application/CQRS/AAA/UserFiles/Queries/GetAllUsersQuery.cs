using MediatR;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries
{
    public class GetAllUsersQuery : IRequest<HandlerResponse<BaseGridDto<UserDisplayDto>>>
    {
        public UserSearchDto? SearchDto { get; }

        public GetAllUsersQuery(UserSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}
