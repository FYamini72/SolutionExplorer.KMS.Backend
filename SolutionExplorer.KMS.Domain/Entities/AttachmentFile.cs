using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class AttachmentFile : BaseEntity
    {
        public string FileName { get; set; }
        public long Size { get; set; }
        public FileCategory FileCategory { get; set; }
        //public string Url { get; set; }
    }
}
