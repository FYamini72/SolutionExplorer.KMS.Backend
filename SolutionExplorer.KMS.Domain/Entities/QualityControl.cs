using SolutionExplorer.KMS.Domain.Entities.AAA;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class QualityControl : BaseEntity
    {
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        /// <summary>
        /// چه چیزی تولید می‌کند
        /// </summary>
        public string Produces { get; set; }

        public DateTime SampleDate { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Series { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        
        public int StorageConditionId { get; set; }
        [ForeignKey(nameof(StorageConditionId))]
        public StorageCondition StorageCondition { get; set; }

        ///// <summary>
        ///// مشخصات ظاهری
        ///// </summary>
        //public string? PhysicalSpecification { get; set; }

        public int? PerformedByUserId { get; set; }
        [ForeignKey(nameof(PerformedByUserId))]
        public User? PerformedByUser { get; set; }

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

        public bool IsConfirmed { get; set; }

        public bool IsDefaultValue { get; set; }

        public ICollection<QualityControlResult> QualityControlResults { get; set; }
        public ICollection<PhysicalSpecification> PhysicalSpecifications { get; set; }
    }
}
