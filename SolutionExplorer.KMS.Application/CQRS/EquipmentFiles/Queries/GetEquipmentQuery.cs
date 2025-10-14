using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Queries
{
    public class GetEquipmentQuery : IRequest<HandlerResponse<EquipmentDisplayDto>>
    {
        public int Id { get; }

        public GetEquipmentQuery(int id)
        {
            Id = id;
        }
    }
}