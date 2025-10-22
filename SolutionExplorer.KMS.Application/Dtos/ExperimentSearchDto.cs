
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class ExperimentSearchDto : BaseSearchDto
    {
        public int? IdentifierId { get; set; }
        public string? Title { get; set; }
        public string? Code { get; set; }
        public int? IsActive { get; set; }
        public int? FirstConfirmerUserId { get; set; }
        public int? SecondConfirmerUserId { get; set; }
    }
}