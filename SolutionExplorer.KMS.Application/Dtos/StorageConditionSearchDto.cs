namespace SolutionExplorer.KMS.Application.Dtos
{
    public class StorageConditionSearchDto : BaseSearchDto
    {
        public int? QualityControlBaseInfoId { get; set; }
        public string? Title { get; set; }
    }
}