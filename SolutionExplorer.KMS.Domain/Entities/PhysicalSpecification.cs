using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
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

    public class PeriodicQCPhysicalSpecification : BaseEntity
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
        public int PeriodicQualityControlId { get; set; }
        [ForeignKey(nameof(PeriodicQualityControlId))]
        public PeriodicQualityControl PeriodicQualityControl { get; set; }

        public bool IsChecked { get; set; }
    }
}
