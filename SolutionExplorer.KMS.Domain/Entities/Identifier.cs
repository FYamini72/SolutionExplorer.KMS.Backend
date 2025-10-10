using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    /// <summary>
    /// اطلاعات اسناد را نگهداری می‌کند.
    /// </summary>
    public class Identifier : BaseEntity
    {
        /// <summary>
        /// اسم سند
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// شماره سند
        /// </summary>
        public string? DocumentNumber { get; set; }

        /// <summary>
        /// دسته بندی سند
        /// </summary>
        public DocumentCategory Category { get; set; }

        /// <summary>
        /// شماره ویرایش
        /// </summary>
        public string? EditNo { get; set; }

        /// <summary>
        /// شناسه دیتابیسی کاربر تهیه کننده
        /// </summary>
        public int? ProducerUserId { get; set; }
        [ForeignKey(nameof(ProducerUserId))]
        public User? ProducerUser { get; set; }

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
