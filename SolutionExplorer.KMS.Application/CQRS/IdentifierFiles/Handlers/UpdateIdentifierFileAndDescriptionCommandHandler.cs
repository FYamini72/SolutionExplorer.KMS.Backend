using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.CQRS.IdentifierFiles.Handlers
{
    public class UpdateIdentifierFileAndDescriptionCommandHandler : IRequestHandler<UpdateIdentifierFileAndDescriptionCommand, HandlerResponse<IdentifierDisplayDto>>
    {
        private readonly IBaseService<Identifier> _service;
        private readonly IAttachmentFileService _attachmentFileService;

        public UpdateIdentifierFileAndDescriptionCommandHandler(IBaseService<Identifier> service, IAttachmentFileService attachmentFileService)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
        }

        public async Task<HandlerResponse<IdentifierDisplayDto>> Handle(UpdateIdentifierFileAndDescriptionCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.AttachmentFile)
                .Include(x => x.ProducerUser)
                .Include(x => x.FirstConfirmerUser)
                .Include(x => x.SecondConfirmerUser)
                .FirstOrDefaultAsync(x => x.Id == request.Identifier.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            if (obj.AttachmentFileId.HasValue && request.Identifier.SelectedFile != null && request.Identifier.SelectedFile.Length > 0)
                await _attachmentFileService.DeleteAsync(obj.AttachmentFileId.Value, cancellationToken);

            obj.AttachmentFile = await _attachmentFileService.UploadFile(request.Identifier.SelectedFile, FileCategory.IdentifierAttachment, cancellationToken);

            request.Identifier.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);

            if (result.AttachmentFileId.HasValue && result.AttachmentFile == null)
                result.AttachmentFile = await _attachmentFileService.GetByIdAsync(cancellationToken, result.AttachmentFileId);

            return result.Adapt<IdentifierDisplayDto>();
        }
    }
}
