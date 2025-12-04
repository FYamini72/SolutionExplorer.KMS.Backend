using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.QualityControlBaseInfoFiles.Queries
{
    public class GetAllQualityControlBaseInfosQuery : IRequest<HandlerResponse<BaseGridDto<QualityControlBaseInfoDisplayDto>>>
    {
        public QualityControlBaseInfoSearchDto? SearchDto { get; }

        public GetAllQualityControlBaseInfosQuery(QualityControlBaseInfoSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}