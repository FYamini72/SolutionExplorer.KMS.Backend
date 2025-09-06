using MediatR;
using SolutionExplorer.KMS.Application.Dtos.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.RoleFiles.Queries
{
    public class GetRoleQuery : IRequest<HandlerResponse<RoleDisplayDto>>
    {
        public int Id { get; }

        public GetRoleQuery(int id)
        {
            Id = id;
        }
    }
}