using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Queries
{
    public class GetReferenceQuery : IRequest<HandlerResponse<ReferenceDisplayDto>>
    {
        public int Id { get; }

        public GetReferenceQuery(int id)
        {
            Id = id;
        }
    }
}