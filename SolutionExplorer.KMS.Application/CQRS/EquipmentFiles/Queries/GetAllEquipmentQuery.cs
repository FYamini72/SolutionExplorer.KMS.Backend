using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.EquipmentFiles.Queries
{
    public class GetAllEquipmentQuery : IRequest<HandlerResponse<BaseGridDto<EquipmentDisplayDto>>>
    {
        public EquipmentSearchDto? SearchDto { get; }

        public GetAllEquipmentQuery(EquipmentSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}