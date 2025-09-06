using MediatR;
using SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Commands;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Services.Interfaces.AAA;

namespace SolutionExplorer.KMS.Application.CQRS.AAA.UserFiles.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, HandlerResponse<bool>>
    {
        private readonly IUserService _UserService;
        private readonly IAttachmentFileService _attachmentFileService;

        public DeleteUserCommandHandler(IUserService UserService, IAttachmentFileService attachmentFileService)
        {
            _UserService = UserService;
            _attachmentFileService = attachmentFileService;
        }

        public async Task<HandlerResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _UserService.GetByIdAsync(cancellationToken, request.Id);

            if (user == null)
                return new(false, "کاربر موردنظر یافت نشد", false);

            if (user.ProfileId.HasValue)
                await _attachmentFileService.DeleteAsync(user.ProfileId.Value, cancellationToken);

            await _UserService.DeleteAsync(user, cancellationToken);
            return true;
        }
    }
}
