using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.PeriodicQualityControlFiles.Queries
{
    public class GetAllPeriodicQualityControlsQuery : IRequest<HandlerResponse<BaseGridDto<PeriodicQualityControlDisplayDto>>>
    {
        public PeriodicQualityControlSearchDto? SearchDto { get; }

        public GetAllPeriodicQualityControlsQuery(PeriodicQualityControlSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}