namespace SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf
{
    public interface IDocumentGenerator
    {
        /// <summary>
        /// تولید PDF رمزنگاری شده - خروجی بایت‌ها
        /// </summary>
        byte[] GenerateEncryptedPdf(string templateFilePath, Dictionary<string, string> textReplacements, Dictionary<string, string> imageReplacements);
    }
}
