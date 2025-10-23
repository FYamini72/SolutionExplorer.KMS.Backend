using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands
{
    public class UpdateIdentifierFileAndDescriptionCommand : IRequest<HandlerResponse<IdentifierDisplayDto>>
    {
        public IdentifierChangeFileAndDescriptionDto Identifier { get; }

        public UpdateIdentifierFileAndDescriptionCommand(IdentifierChangeFileAndDescriptionDto Identifier)
        {
            this.Identifier = Identifier;
        }
    }
}