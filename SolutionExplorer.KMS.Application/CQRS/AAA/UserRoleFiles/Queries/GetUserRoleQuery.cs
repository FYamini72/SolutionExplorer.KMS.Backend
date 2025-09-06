using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserRoleFiles.Queries
{
    public class GetUserRoleQuery : IRequest<HandlerResponse<UserRoleDisplayDto>>
    {
        public int Id { get; }

        public GetUserRoleQuery(int id)
        {
            Id = id;
        }
    }
}