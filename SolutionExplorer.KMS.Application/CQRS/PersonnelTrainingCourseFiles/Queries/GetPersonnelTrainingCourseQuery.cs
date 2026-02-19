using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelTrainingCourseFiles.Queries
{
    public class GetPersonnelTrainingCourseQuery : IRequest<HandlerResponse<PersonnelTrainingCourseDisplayDto>>
    {
        public int Id { get; }

        public GetPersonnelTrainingCourseQuery(int id)
        {
            Id = id;
        }
    }
}