using Microsoft.AspNetCore.Mvc;
using SolutionExplorer.KMS.API.Utilities.Filters;
using SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf;

namespace SolutionExplorer.KMS.API.Controllers.DocxToPdf
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentGenerator _documentGenerator;
        private readonly IWebHostEnvironment _env;

        public DocumentController(IDocumentGenerator documentGenerator, IWebHostEnvironment env)
        {
            _documentGenerator = documentGenerator;
            _env = env;
        }

        /// <summary>
        /// تولید PDF رمزنگاری‌شده بر اساس قالب و داده‌های ورودی
        /// </summary>
        /// <param name="request">اطلاعات لازم برای تولید سند</param>
        [HttpGet("generate-encrypted-pdf")]
        public IActionResult GenerateEncryptedPdf()
        {
            var webRoot = _env.WebRootPath;
            if (string.IsNullOrEmpty(webRoot))
                webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var templateFile = Path.Combine(webRoot, "doc1.docx");
            if (!System.IO.File.Exists(templateFile))
                return StatusCode(500, "Template file not found: " + templateFile);

            // نقشه جایگزینی متن
            var textReplacements = new Dictionary<string, string>(StringComparer.Ordinal)
            {
                { "DocumentName", "سند آزمایشی شماره 1" },
                { "DocumentNumber", "DOC-Yamini-20250909" },
                { "ConfirmerOneName", "فرزام یمینی" },
                { "ConfirmerTwoName", "عرفان تهوری" }
            };

            // نقشه جایگزینی تصاویر: مقدارها اسم فایل داخل wwwroot/images هستند
            var imageReplacements = new Dictionary<string, string>(StringComparer.Ordinal)
            {
                { "ConfirmerOneSignImage", Path.Combine(webRoot, "images", "sample1.jpg") },
                { "ConfirmerTwoSignImage", Path.Combine(webRoot, "images", "sample2.png") }
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
