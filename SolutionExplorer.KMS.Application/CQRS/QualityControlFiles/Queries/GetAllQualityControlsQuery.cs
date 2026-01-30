using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.QualityControlFiles.Queries
{
    public class GetAllQualityControlsQuery : IRequest<HandlerResponse<BaseGridDto<QualityControlDisplayDto>>>
    {
        public QualityControlSearchDto? SearchDto { get; }

        public GetAllQualityControlsQuery(QualityControlSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}