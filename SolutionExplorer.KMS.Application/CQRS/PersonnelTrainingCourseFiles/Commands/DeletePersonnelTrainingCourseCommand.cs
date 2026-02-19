using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Commands
{
    public class DeletePersonnelTrainingCourseCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeletePersonnelTrainingCourseCommand(int id)
        {
            Id = id;
        }
    }
}