using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Queries
{
    public class GetUserQuery : IRequest<HandlerResponse<UserDisplayDto>>
    {
        public int Id { get; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
