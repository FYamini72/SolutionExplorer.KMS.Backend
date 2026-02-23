using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Commands
{
    public class CreatePersonnelTrainingCourseCommand : IRequest<HandlerResponse<PersonnelTrainingCourseDisplayDto>>
    {
        public PersonnelTrainingCourseCreateDto PersonnelTrainingCourse { get; }

        public CreatePersonnelTrainingCourseCommand(PersonnelTrainingCourseCreateDto PersonnelTrainingCourse)
        {
            this.PersonnelTrainingCourse = PersonnelTrainingCourse;
        }
    }
}