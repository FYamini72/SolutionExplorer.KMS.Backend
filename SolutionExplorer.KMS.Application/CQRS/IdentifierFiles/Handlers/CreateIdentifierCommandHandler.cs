using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using Mapster;
using MediatR;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class CreateIdentifierCommandHandler : IRequestHandler<CreateIdentifierCommand, HandlerResponse<IdentifierDisplayDto>>
    {
        private readonly IBaseService<Identifier> _service;

        public CreateIdentifierCommandHandler(IBaseService<Identifier> service)
        {
            _service = service;
        }

        public async Task<HandlerResponse<IdentifierDisplayDto>> Handle(CreateIdentifierCommand request, CancellationToken cancellationToken)
        {
            var Identifier = request.Identifier.Adapt<Identifier>();

            var result = await _service.AddAsync(Identifier, cancellationToken);
            return result.Adapt<IdentifierDisplayDto>();
        }
    }
}
