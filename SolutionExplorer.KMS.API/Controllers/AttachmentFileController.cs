using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Domain.Entities;
using SolutionExplorer.KMS.Application.Utilities;

namespace SolutionExplorer.KMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class AttachmentFileController : ControllerBase
    {
        private readonly IBaseService<AttachmentFile> _attachmentFileService;

        public AttachmentFileController(IBaseService<AttachmentFile> attachmentFileService)
        {
            _attachmentFileService = attachmentFileService;
        }

        [HttpGet("[action]/{attachmentFileId:int}")]
        public async Task<IActionResult> DownloadAttachment(int attachmentFileId, CancellationToken cancellationToken)
        {
            var attachmentFile = await _attachmentFileService.GetByIdAsync(cancellationToken, attachmentFileId);
            var filePath = attachmentFile.GetFileDirectory(FileAccessMode.Write);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var contentType = "application/octet-stream";
            var fileName = Path.GetFileName(filePath);
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath, cancellationToken);

            Response.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");
            return File(bytes, contentType);
            //return File(bytes, contentType, fileName); // ← هدر Download خودکار اضافه می‌شود
        }
    }
}
