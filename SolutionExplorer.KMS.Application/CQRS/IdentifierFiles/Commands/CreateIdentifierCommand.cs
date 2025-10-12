using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands
{
    public class CreateIdentifierCommand : IRequest<HandlerResponse<IdentifierDisplayDto>>
    {
        public IdentifierCreateDto Identifier { get; }

        public CreateIdentifierCommand(IdentifierCreateDto Identifier)
        {
            this.Identifier = Identifier;
        }
    }
}