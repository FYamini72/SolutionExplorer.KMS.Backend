
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class ExperimentDisplayDto : BaseDto
    {
		public int IdentifierId { get; set; }
		public string? Title { get; set; }
		public string? Code { get; set; }
		public bool IsActive { get; set; }
        public int FirstConfirmerUserId { get; set; }
        public string? FirstConfirmerUserFullName { get; set; }
        public int SecondConfirmerUserId { get; set; }
        public string? SecondConfirmerUserFullName { get; set; }
    }
}