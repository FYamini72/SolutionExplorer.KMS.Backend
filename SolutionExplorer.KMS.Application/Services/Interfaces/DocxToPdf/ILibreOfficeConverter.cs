namespace SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf
{
    public interface ILibreOfficeConverter
    {
        /// <summary>
        /// تبدیل DOCX به PDF با LibreOffice (soffice)
        /// </summary>
        void ConvertToPdf(string docxPath, string outputPdfPath, TimeSpan? timeout = null);
    }
}
