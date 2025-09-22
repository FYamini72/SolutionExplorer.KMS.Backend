using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.Services.Interfaces;
using SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf;
using SolutionExplorer.KMS.Domain.Entities.Documents;
using System.Threading.Tasks;

namespace SolutionExplorer.KMS.API.Controllers.DocxToPdf
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentGenerator _documentGenerator;
        private readonly IBaseService<DocumentInfo> _documentService;
        private readonly IWebHostEnvironment _env;

        public DocumentController(IDocumentGenerator documentGenerator, IBaseService<DocumentInfo> documentService, IWebHostEnvironment env)
        {
            _documentGenerator = documentGenerator;
            _documentService = documentService;
            _env = env;
        }

        /// <summary>
        /// تولید PDF رمزنگاری‌شده بر اساس قالب و داده‌های ورودی
        /// </summary>
        /// <param name="request">اطلاعات لازم برای تولید سند</param>
        [HttpGet("generate-encrypted-pdf/{documentInfoId:int}")]
        public async Task<IActionResult> GenerateEncryptedPdf(int documentInfoId, CancellationToken cancellationToken)
        {
            var webRoot = _env.WebRootPath;
            if (string.IsNullOrEmpty(webRoot))
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var docInfo = await _documentService.GetByIdAsync(cancellationToken, documentInfoId);
            if (docInfo == null)
                return BadRequest("سند مورد نظر یافت نشد.");

            var templateFile = Path.Combine(webRoot, "Documents", docInfo.FileName);
            if (!System.IO.File.Exists(templateFile))
                return BadRequest("فایل مورد نظر یافت نشد.");

            // نقشه جایگزینی متن
            var textReplacements = new Dictionary<string, string>(StringComparer.Ordinal)
            {
                { "LabName", docInfo.LabName },
                { "EditeNumber", docInfo.EditNumber },
                { "EditeDate", docInfo.EditDate },
                { "ReviewDate", docInfo.ReviewDate },
                { "ConfirmerOneName", docInfo.ConfirmerOneName },
                { "ConfirmerTwoName", docInfo.ConfirmerTwoName }
            };

            // نقشه جایگزینی تصاویر: مقدارها اسم فایل داخل wwwroot/images هستند
            var imageReplacements = new Dictionary<string, string>(StringComparer.Ordinal)
            {
                { "ConfirmerOneSignImage", Path.Combine(webRoot, "images", docInfo.ConfirmerOneSignImage) },
                { "ConfirmerTwoSignImage", Path.Combine(webRoot, "images", docInfo.ConfirmerTwoSignImage) }
            };

            try
            {
                var encryptedPdfBytes = _documentGenerator.GenerateEncryptedPdf(
                    templateFile,
                    textReplacements,
                    imageReplacements
                );

                //// دانلود فایل
                //return File(encryptedPdfBytes, "application/pdf", "encrypted.pdf");

                // برگرداندن داده رمزنگاری شده به عنوان یک فایل باینری
                return File(encryptedPdfBytes, "application/octet-stream", "document.pdf.enc");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating PDF: {ex.Message}");
            }
        }
    }
}
