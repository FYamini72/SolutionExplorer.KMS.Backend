using SolutionExplorer.KMS.Domain.Entities.AAA;
using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    /// <summary>
    /// اطلاعات پرسنل را نگهداری می‌کند.
    /// </summary>
    [Table(nameof(Personnel))]
    public class Personnel : User
    {
        /// <summary>
        /// پیشوند پرسنل
        /// </summary>
        public Prefix Prefix { get; set; }

        /// <summary>
        /// جنسیت پرسنل
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// سمت و مقام پرسنل
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// مدرک تحصیلی پرسنل
        /// </summary>
        public EducationalDegree EducationalDegree { get; set; }

        /// <summary>
        /// رشته تحصیلی پرسنل
        /// </summary>
        public string EducationalField { get; set; }

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

        /// <summary>
        /// شناسه دیتابیسی جانشین
        /// </summary>
        public int? SuccessorUserId { get; set; }
        [ForeignKey(nameof(SuccessorUserId))]
        public User? SuccessorUser { get; set; }

        /// <summary>
        /// چارت سازمانی
        /// </summary>
        public string? OrganizationalChart { get; set; }
    }
}
