using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Queries
{
    public class GetAllPersonnelsQuery : IRequest<HandlerResponse<BaseGridDto<PersonnelDisplayDto>>>
    {
        public PersonnelSearchDto? SearchDto { get; }

        public GetAllPersonnelsQuery(PersonnelSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}