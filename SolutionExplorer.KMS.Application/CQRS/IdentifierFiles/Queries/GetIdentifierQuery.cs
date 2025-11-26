using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Queries
{
    public class GetIdentifierQuery : IRequest<HandlerResponse<IdentifierDisplayDto>>
    {
        public int Id { get; }

        public GetIdentifierQuery(int id)
        {
            Id = id;
        }
    }
}