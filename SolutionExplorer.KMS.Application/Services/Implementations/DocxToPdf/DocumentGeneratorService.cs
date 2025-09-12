using SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf;
using System.Text;

namespace SolutionExplorer.KMS.Application.Services.Implementations.DocxToPdf
{
    public class DocumentGeneratorService : IDocumentGenerator
    {
        private readonly ITemplateProcessor _templateProcessor;
        private readonly ILibreOfficeConverter _converter;
        private readonly IEncryptionService _encryptionService;

        public DocumentGeneratorService(ITemplateProcessor templateProcessor, ILibreOfficeConverter converter, IEncryptionService encryptionService)
        {
            _templateProcessor = templateProcessor;
            _converter = converter;
            _encryptionService = encryptionService;
        }

        public byte[] GenerateEncryptedPdf(string templateFilePath, Dictionary<string, string> textReplacements, Dictionary<string, string> imageReplacements)
        {
            var tempDir = Path.Combine(Path.GetTempPath(), "docgen", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);
            var workingDocx = Path.Combine(tempDir, "out.docx");
            var outputPdf = Path.Combine(tempDir, "out.pdf");

            try
            {
                _templateProcessor.ProcessTemplate(templateFilePath, workingDocx, textReplacements, imageReplacements);
                _converter.ConvertToPdf(workingDocx, outputPdf);

                var pdfBytes = File.ReadAllBytes(outputPdf);

                var encrypted = _encryptionService.EncryptAes(pdfBytes);

                return encrypted;
            }
            finally
            {
                try { if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true); } catch { }
            }
        }
    }
}
