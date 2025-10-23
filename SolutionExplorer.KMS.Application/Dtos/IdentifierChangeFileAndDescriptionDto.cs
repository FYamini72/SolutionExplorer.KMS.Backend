namespace SolutionExplorer.KMS.Application.Dtos
{
    public class IdentifierChangeFileAndDescriptionDto : BaseDto
    {
        public string? Description { get; set; }
        public int? AttachmentFileId { get; set; }
    }
}