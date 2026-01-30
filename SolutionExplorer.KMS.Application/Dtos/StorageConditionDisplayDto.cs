namespace SolutionExplorer.KMS.Application.Dtos
{
    public class StorageConditionDisplayDto : BaseDto
    {
        public int QualityControlBaseInfoId { get; set; }

        public string Title { get; set; }
        public bool IsSelected { get; set; }
    }
}