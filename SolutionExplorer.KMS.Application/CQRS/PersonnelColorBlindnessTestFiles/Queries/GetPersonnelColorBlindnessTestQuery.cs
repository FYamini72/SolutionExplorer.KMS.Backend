using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Queries
{
    public class GetPersonnelColorBlindnessTestQuery : IRequest<HandlerResponse<PersonnelColorBlindnessTestDisplayDto>>
    {
        public int Id { get; }

        public GetPersonnelColorBlindnessTestQuery(int id)
        {
            Id = id;
        }
    }
}