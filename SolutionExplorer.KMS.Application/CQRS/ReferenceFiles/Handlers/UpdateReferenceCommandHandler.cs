using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos;
using SolutionExplorer.KMS.Application.Services.Implementations;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.CQRS.ReferenceFiles.Handlers
{
    public class UpdateReferenceCommandHandler : IRequestHandler<UpdateReferenceCommand, HandlerResponse<ReferenceDisplayDto>>
    {
        private readonly IBaseService<Reference> _service;
        private readonly IAttachmentFileService _attachmentFileService;

        public UpdateReferenceCommandHandler(IBaseService<Reference> service, IAttachmentFileService attachmentFileService)
        {
            _service = service;
            _attachmentFileService = attachmentFileService;
        }

        public async Task<HandlerResponse<ReferenceDisplayDto>> Handle(UpdateReferenceCommand request, CancellationToken cancellationToken)
        {
            var obj = await _service
                .GetAll()
                .Include(x => x.AttachmentFile)
                .FirstOrDefaultAsync(x => x.Id == request.Reference.Id, cancellationToken);

            if (obj == null)
                return new(false, "رکورد مورد نظر یافت نشد", null);

            if (request.Reference.SelectedFile != null && request.Reference.SelectedFile.Length > 0)
            {
                await _attachmentFileService.DeleteAsync(obj.AttachmentFileId, cancellationToken);
                obj.AttachmentFile = await _attachmentFileService.UploadFile(request.Reference.SelectedFile, FileCategory.References, cancellationToken);
            }

            request.Reference.Adapt(obj);
            var result = await _service.UpdateAsync(obj, cancellationToken);
            result.AttachmentFile = await _attachmentFileService.GetByIdAsync(cancellationToken, result.AttachmentFileId);

            return result.Adapt<ReferenceDisplayDto>();
        }
    }
}
