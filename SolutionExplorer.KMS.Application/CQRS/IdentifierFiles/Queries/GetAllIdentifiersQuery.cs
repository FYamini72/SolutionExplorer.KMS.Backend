using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Queries
{
    public class GetAllIdentifiersQuery : IRequest<HandlerResponse<BaseGridDto<IdentifierDisplayDto>>>
    {
        public IdentifierSearchDto? SearchDto { get; }

        public GetAllIdentifiersQuery(IdentifierSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}