using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Queries
{
    public class GetPersonnelQuery : IRequest<HandlerResponse<PersonnelDisplayDto>>
    {
        public int Id { get; }

        public GetPersonnelQuery(int id)
        {
            Id = id;
        }
    }
}