using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Queries
{
    public class GetAllReferencesQuery : IRequest<HandlerResponse<BaseGridDto<ReferenceDisplayDto>>>
    {
        public ReferenceSearchDto? SearchDto { get; }

        public GetAllReferencesQuery(ReferenceSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}