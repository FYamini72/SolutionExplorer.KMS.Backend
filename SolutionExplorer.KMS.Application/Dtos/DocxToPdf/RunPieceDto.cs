using DocumentFormat.OpenXml.Wordprocessing;

namespace SolutionExplorer.KMS.Application.Dtos.DocxToPdf
{
    public class RunPieceDto
    {
        public Run Run { get; set; }
        public Text TextElement { get; set; }
        public string Text { get; set; }
    }
}
