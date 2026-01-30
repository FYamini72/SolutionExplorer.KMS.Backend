
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class QualityControlSearchDto : BaseSearchDto
    {
        public int? QualityControlBaseInfoId { get; set; }
        public int? PerformedByUserId { get; set; }
        public int? FirstConfirmerUserId { get; set; }
        public int? SecondConfirmerUserId { get; set; }
        public int? IsConfirmed { get; set; }
    }
}