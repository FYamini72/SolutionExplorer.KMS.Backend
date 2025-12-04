using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Queries
{
    public class GetQualityControlQuery : IRequest<HandlerResponse<QualityControlDisplayDto>>
    {
        public int Id { get; }

        public GetQualityControlQuery(int id)
        {
            Id = id;
        }
    }
}