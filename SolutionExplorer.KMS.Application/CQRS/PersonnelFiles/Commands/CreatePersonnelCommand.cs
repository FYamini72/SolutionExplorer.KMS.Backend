using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Commands
{
    public class CreatePersonnelCommand : IRequest<HandlerResponse<PersonnelDisplayDto>>
    {
        public PersonnelCreateDto Personnel { get; }

        public CreatePersonnelCommand(PersonnelCreateDto Personnel)
        {
            this.Personnel = Personnel;
        }
    }
}