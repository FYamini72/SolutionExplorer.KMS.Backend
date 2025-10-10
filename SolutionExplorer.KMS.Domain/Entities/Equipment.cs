using SolutionExplorer.KMS.Domain.Entities.AAA;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class Equipment : BaseEntity
    {
        /// <summary>
        /// شناسه دیتابیسی سند
        /// </summary>
        public int IdentifierId { get; set; }
        [ForeignKey(nameof(IdentifierId))]
        public Identifier Identifier { get; set; }

        /// <summary>
        /// نام دستگاه
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// کد دستگاه
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// مدل
        /// </summary>
        public string? EquipmentModel { get; set; }

        /// <summary>
        /// شماره سریال
        /// </summary>
        public string? SerialNo { get; set; }

        /// <summary>
        /// کارخانه سازنده
        /// </summary>
        public string? Manufacturer { get; set; }

        /// <summary>
        /// کشور سازنده
        /// </summary>
        public string? ManufactureCountry { get; set; }

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
