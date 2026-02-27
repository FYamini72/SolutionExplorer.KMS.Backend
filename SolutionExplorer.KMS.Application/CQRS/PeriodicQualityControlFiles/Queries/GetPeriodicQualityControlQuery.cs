using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Queries
{
    public class GetPeriodicQualityControlQuery : IRequest<HandlerResponse<PeriodicQualityControlDisplayDto>>
    {
        public int Id { get; }

        public GetPeriodicQualityControlQuery(int id)
        {
            Id = id;
        }
    }
}