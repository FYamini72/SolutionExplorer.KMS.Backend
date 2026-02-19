using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.PersonnelColorBlindnessTestFiles.Commands
{
    public class DeletePersonnelColorBlindnessTestCommand : IRequest<HandlerResponse<bool>>
    {
        public int Id { get; }

        public DeletePersonnelColorBlindnessTestCommand(int id)
        {
            Id = id;
        }
    }
}