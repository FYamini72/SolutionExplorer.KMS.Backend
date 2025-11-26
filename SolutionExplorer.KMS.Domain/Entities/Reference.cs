using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    /// <summary>
    /// منابع
    /// </summary>
    public class Reference : BaseEntity
    {
        /// <summary>
        /// شناسه دیتابیسی شناسنامه
        /// </summary>
        public int IdentifierId { get; set; }
        [ForeignKey(nameof(IdentifierId))]
        public Identifier Identifier { get; set; }

        /// <summary>
        /// عنوان منبع
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// فایل پیوست
        /// </summary>
        public int AttachmentFileId { get; set; }
        [ForeignKey(nameof(AttachmentFileId))]
        public AttachmentFile AttachmentFile { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string? Description { get; set; }
    }
}
