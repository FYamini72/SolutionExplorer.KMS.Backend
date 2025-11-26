using Mapster;
using MediatR;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class CreateIdentifierCommandHandler : IRequestHandler<CreateIdentifierCommand, HandlerResponse<IdentifierDisplayDto>>
    {
        private readonly IBaseService<Identifier> _service;
        private readonly IAttachmentFileService _attachmentFileService;

        public CreateIdentifierCommandHandler(IBaseService<Identifier> service, IAttachmentFileService attachmentFileService)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
        }

        public async Task<HandlerResponse<IdentifierDisplayDto>> Handle(CreateIdentifierCommand request, CancellationToken cancellationToken)
        {
            var identifier = request.Identifier.Adapt<Identifier>();

            if (request.Identifier.SelectedFile != null)
                identifier.AttachmentFile = await _attachmentFileService.UploadFile(request.Identifier.SelectedFile, FileCategory.IdentifierAttachment, cancellationToken);

            var result = await _service.AddAsync(identifier, cancellationToken);

            if (result.AttachmentFileId.HasValue && result.AttachmentFile == null)
                result.AttachmentFile = await _attachmentFileService.GetByIdAsync(cancellationToken, result.AttachmentFileId);

            return result.Adapt<IdentifierDisplayDto>();
        }
    }
}
