using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Queries
{
    public class GetAllPersonnelColorBlindnessTestsQuery : IRequest<HandlerResponse<BaseGridDto<PersonnelColorBlindnessTestDisplayDto>>>
    {
        public PersonnelColorBlindnessTestSearchDto? SearchDto { get; }

        public GetAllPersonnelColorBlindnessTestsQuery(PersonnelColorBlindnessTestSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}