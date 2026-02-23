using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Commands
{
    public class UpdatePersonnelTrainingCourseCommand : IRequest<HandlerResponse<PersonnelTrainingCourseDisplayDto>>
    {
        public PersonnelTrainingCourseCreateDto PersonnelTrainingCourse { get; }

        public UpdatePersonnelTrainingCourseCommand(PersonnelTrainingCourseCreateDto PersonnelTrainingCourse)
        {
            this.PersonnelTrainingCourse = PersonnelTrainingCourse;
        }
    }
}