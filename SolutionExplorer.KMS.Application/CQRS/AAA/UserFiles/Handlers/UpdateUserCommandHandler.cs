using Mapster;
using MediatR;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Commands;
using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Services.Interfaces.AAA;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, HandlerResponse<UserDisplayDto>>
    {
        private readonly IUserService _userService;
        private readonly IAttachmentFileService _attachmentFileService;

        public UpdateUserCommandHandler(IUserService userService, IAttachmentFileService attachmentFileService)
        {
            _userService = userService;
            _attachmentFileService = attachmentFileService;
        }

        public async Task<HandlerResponse<UserDisplayDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var obj = await _userService.GetByIdAsync(cancellationToken, request.User.Id);

            if (obj == null)
                return new(false, ";کاربر مورد نظر یافت نشد", null);

            if (obj.ProfileId.HasValue && request.User.SelectedFile != null && request.User.SelectedFile.Length > 0)
                await _attachmentFileService.DeleteAsync(obj.ProfileId.Value, cancellationToken);

            request.User.Adapt(obj);

            if (!String.IsNullOrEmpty(request.User.NewPassword))
            {
                obj.PasswordHash = request.User.NewPassword.GetSha256Hash();
            }

            obj.SecurityStamp = Guid.NewGuid();

            obj.Profile = await _attachmentFileService.UploadFile(request.User.SelectedFile, FileCategory.UserProfile, cancellationToken);

            var result = await _userService.UpdateAsync(obj, cancellationToken);

            if (result.ProfileId.HasValue && result.Profile == null)
                result.Profile = await _attachmentFileService.GetByIdAsync(cancellationToken, result.ProfileId);

            return result.Adapt<UserDisplayDto>();
        }
    }
}
