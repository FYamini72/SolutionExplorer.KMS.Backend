using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SolutionExplorer.KMS.Application.Repositories;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Utilities;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Domain.Enums;
using SolutionExplorer.KMS.Domain.Settings;

namespace SolutionExplorer.KMS.Application.Services.Implementations
{
    public class AttachmentFileService : BaseService<AttachmentFile>, IAttachmentFileService
    {
        private readonly IBaseRepository<AttachmentFile> _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly FilePathConfiguration _fileConfiguration;

        public AttachmentFileService(IBaseRepository<AttachmentFile> repository
            , IWebHostEnvironment webHostEnvironment
            , IBaseRepository<EventLog> eventLogRepository
            , IConfiguration configuration
            , IHttpContextAccessor httpContext
            , FilePathConfiguration fileConfiguration) : base(repository, eventLogRepository, configuration, httpContext)
        {
            this._repository = repository;
            this._webHostEnvironment = webHostEnvironment;
            this._fileConfiguration = fileConfiguration;
        }

        public async Task<AttachmentFile?> UploadFile(IFormFile file, FileCategory fileCategory, CancellationToken cancellationToken)
        {
            if (file != null && file.Length > 0)
            {
                string filename = $"{Guid.NewGuid().ToString().Trim()}{Path.GetExtension(file.FileName)}";
                var size = file.Length;
                string strFilePathName = Path.Combine(AttachmentUrlResolver.GetFolderDirectory(fileCategory, FileAccessMode.Write), filename);

                using (var fileStream = new FileStream(strFilePathName, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream, cancellationToken);
                }

                return new AttachmentFile()
                {
                    FileName = filename,
                    Size = size,
                    FileCategory = fileCategory
                };
            }

            return null;
        }

        public void DeleteFile(int id)
        {
            var file = _repository.GetById(id);
            DeleteFile(file);
        }

        public async Task DeleteFile(int id, CancellationToken cancellationToken)
        {
            var file = await _repository.GetByIdAsync(cancellationToken, id);
            DeleteFile(file);
        }

        public void DeleteFile(AttachmentFile file)
        {
            if (file != null)
            {
                var strFilePath = Path.Combine(AttachmentUrlResolver.GetFolderDirectory(file.FileCategory, FileAccessMode.Write), file.FileName);

                if (File.Exists(strFilePath))
                    File.Delete(strFilePath);
            }
        }

        public override void Delete(AttachmentFile entity, bool saveNow = true)
        {
            base.Delete(entity, saveNow);
            DeleteFile(entity);
        }

        public override async Task DeleteAsync(AttachmentFile entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            await base.DeleteAsync(entity, cancellationToken, saveNow);
            DeleteFile(entity);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken, bool saveNow = true)
        {
            var obj = await GetByIdAsync(cancellationToken, id);
            await DeleteAsync(obj, cancellationToken, saveNow);
        }

        public void Delete(int id, bool saveNow = true)
        {
            var obj = GetById(id);
            Delete(obj, saveNow);
        }
    }
}
