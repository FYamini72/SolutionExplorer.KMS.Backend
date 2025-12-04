using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Queries
{
    public class GetQualityControlBaseInfoQuery : IRequest<HandlerResponse<QualityControlBaseInfoDisplayDto>>
    {
        public int Id { get; }

        public GetQualityControlBaseInfoQuery(int id)
        {
            Id = id;
        }
    }
}