
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class ReferenceDisplayDto : BaseDto
    {
		public int IdentifierId { get; set; }
		public string? Title { get; set; }
		public int? AttachmentFileId { get; set; }
        public string? AttachmentFileName { get; set; }
        public string? Description { get; set; }
    }
}