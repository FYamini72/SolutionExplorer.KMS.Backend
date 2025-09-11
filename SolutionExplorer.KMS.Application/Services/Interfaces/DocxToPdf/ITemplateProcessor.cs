namespace SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf
{
    public interface ITemplateProcessor
    {
        /// <summary>
        /// پردازش داکیومنت ورد: جایگزینی متن و تصاویر و ذخیره نتیجه روی مسیر خروجی
        /// </summary>
        void ProcessTemplate(string templateFilePath, string outputDocxPath, Dictionary<string, string> textReplacements, Dictionary<string, string> imageReplacements);
    }
}
