using MediatR;
using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Commands
{
    public class UpdateReferenceCommand : IRequest<HandlerResponse<ReferenceDisplayDto>>
    {
        public ReferenceCreateDto Reference { get; }

        public UpdateReferenceCommand(ReferenceCreateDto Reference)
        {
            this.Reference = Reference;
        }
    }
}