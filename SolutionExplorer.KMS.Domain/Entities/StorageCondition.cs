using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class StorageCondition : BaseEntity
    {
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        public string Title { get; set; }
        public bool IsSelected { get; set; }
    }

    public class PhysicalSpecification : BaseEntity
    {
        /// <summary>
        /// اطلاعات پایه کنترل کیفی
        /// </summary>
        public int QCBaseInfoPhysicalSpecificationId { get; set; }
        [ForeignKey(nameof(QCBaseInfoPhysicalSpecificationId))]
        public QCBaseInfoPhysicalSpecification QCBaseInfoPhysicalSpecification { get; set; }

        /// <summary>
        /// کنترل کیفی
        /// </summary>
        public int QualityControlId { get; set; }
        [ForeignKey(nameof(QualityControlId))]
        public QualityControl QualityControl { get; set; }

        public bool IsChecked { get; set; }
    }
}
