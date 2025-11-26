using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands
{
    public class UpdateIdentifierCommand : IRequest<HandlerResponse<IdentifierDisplayDto>>
    {
        public IdentifierCreateDto Identifier { get; }

        public UpdateIdentifierCommand(IdentifierCreateDto Identifier)
        {
            this.Identifier = Identifier;
        }
    }
}