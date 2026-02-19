using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Commands
{
    public class CreatePersonnelColorBlindnessTestCommand : IRequest<HandlerResponse<PersonnelColorBlindnessTestDisplayDto>>
    {
        public PersonnelColorBlindnessTestCreateDto PersonnelColorBlindnessTest { get; }

        public CreatePersonnelColorBlindnessTestCommand(PersonnelColorBlindnessTestCreateDto PersonnelColorBlindnessTest)
        {
            this.PersonnelColorBlindnessTest = PersonnelColorBlindnessTest;
        }
    }
}