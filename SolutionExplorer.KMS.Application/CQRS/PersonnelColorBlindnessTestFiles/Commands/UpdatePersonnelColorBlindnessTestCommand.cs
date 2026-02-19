using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Commands
{
    public class UpdatePersonnelColorBlindnessTestCommand : IRequest<HandlerResponse<PersonnelColorBlindnessTestDisplayDto>>
    {
        public PersonnelColorBlindnessTestCreateDto PersonnelColorBlindnessTest { get; }

        public UpdatePersonnelColorBlindnessTestCommand(PersonnelColorBlindnessTestCreateDto PersonnelColorBlindnessTest)
        {
            this.PersonnelColorBlindnessTest = PersonnelColorBlindnessTest;
        }
    }
}