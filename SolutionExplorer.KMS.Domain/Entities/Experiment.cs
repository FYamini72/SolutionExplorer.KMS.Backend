using SolutionExplorer.KMS.Domain.Entities.AAA;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class Experiment : BaseEntity
    {
        /// <summary>
        /// شناسه دیتابیسی شناسنامه
        /// </summary>
        public int IdentifierId { get; set; }
        [ForeignKey(nameof(IdentifierId))]
        public Identifier Identifier { get; set; }

        /// <summary>
        /// نام آزمایش
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// کد ملی آزمایش
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// وضعیت فعال بودن
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تایید کننده
        /// </summary>
        public int FirstConfirmerUserId { get; set; }
        [ForeignKey(nameof(FirstConfirmerUserId))]
        public User FirstConfirmerUser { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تصدیق کننده 
        /// </summary>
        public int SecondConfirmerUserId { get; set; }
        [ForeignKey(nameof(SecondConfirmerUserId))]
        public User SecondConfirmerUser { get; set; }
    }
}
