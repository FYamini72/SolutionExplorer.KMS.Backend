using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries
{
    public class GetAllUsersForDropDownQuery : IRequest<HandlerResponse<List<KeyValuePair<int, string>>>>
    {
        public UserSearchDto? SearchDto { get; }

        public GetAllUsersForDropDownQuery(UserSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}
