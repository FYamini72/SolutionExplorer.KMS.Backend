using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Commands
{
    public class CreateReferenceCommand : IRequest<HandlerResponse<ReferenceDisplayDto>>
    {
        public ReferenceCreateDto Reference { get; }

        public CreateReferenceCommand(ReferenceCreateDto Reference)
        {
            this.Reference = Reference;
        }
    }
}