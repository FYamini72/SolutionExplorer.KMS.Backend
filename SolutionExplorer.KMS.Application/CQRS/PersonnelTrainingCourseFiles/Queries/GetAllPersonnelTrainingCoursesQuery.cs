using MediatR;
using SolutionExplorer.KMS.Application.Dtos;


namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Queries
{
    public class GetAllPersonnelTrainingCoursesQuery : IRequest<HandlerResponse<BaseGridDto<PersonnelTrainingCourseDisplayDto>>>
    {
        public PersonnelTrainingCourseSearchDto? SearchDto { get; }

        public GetAllPersonnelTrainingCoursesQuery(PersonnelTrainingCourseSearchDto? searchDto)
        {
            this.SearchDto = searchDto;
        }
    }
}