using Microsoft.AspNetCore.Http;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Services.Interfaces
{
    public interface IAttachmentFileService : IBaseService<AttachmentFile>
    {
        void DeleteFile(int id);
        Task DeleteFile(int id, CancellationToken cancellationToken);
        void DeleteFile(AttachmentFile file);
        Task<AttachmentFile?> UploadFile(IFormFile file, FileCategory fileCategory, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken, bool saveNow = true);
        void Delete(int id, bool saveNow = true);
    }
}
