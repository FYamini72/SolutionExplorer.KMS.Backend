namespace SolutionExplorer.KMS.Application.Dtos
{
    public class QCBaseInfoPhysicalSpecificationDisplayDto : BaseDto
    {
        public int QualityControlBaseInfoId { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
    }
}