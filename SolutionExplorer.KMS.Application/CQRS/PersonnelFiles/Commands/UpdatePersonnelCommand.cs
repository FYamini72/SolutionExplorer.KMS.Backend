using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelFiles.Commands
{
    public class UpdatePersonnelCommand : IRequest<HandlerResponse<PersonnelDisplayDto>>
    {
        public PersonnelUpdateDto Personnel { get; }

        public UpdatePersonnelCommand(PersonnelUpdateDto Personnel)
        {
            this.Personnel = Personnel;
        }
    }
}