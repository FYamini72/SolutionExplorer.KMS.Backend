using SolutionExplorer.KMS.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class QualityControlBaseInfo : BaseEntity
    {
        //public string Manufacturer { get; set; }
        //public string Series { get; set; }
        //public DateTime ProductionDate { get; set; }
        //public DateTime ExpirationDate { get; set; }

        //public string? DefaultValue { get; set; }

        public string Title { get; set; }
        public QualityControlPeriod QualityControlPeriod { get; set; }
        public int? DayIntervalCount { get; set; }
        public DateTime NextQualityControlTime { get; set; }
        public QCCategory Category { get; set; }

        public ICollection<StorageCondition> StorageConditions { get; set; }
        public ICollection<QCBaseInfoExpectedResult> QCBaseInfoExpectedResults { get; set; }
        public ICollection<QCBaseInfoPhysicalSpecification> QCBaseInfoPhysicalSpecifications { get; set; }
    }

    public class QCBaseInfoExpectedResult : BaseEntity
    {
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        /// <summary>
        /// ارگانیسم کنترل
        /// </summary>
        public string ATCCControlOrganism { get; set; }

        /// <summary>
        /// نتیجه مورد انتظار
        /// </summary>
        public string? ExpectedResult { get; set; }

        /// <summary>
        /// قطر هاله براساس میلی‌متر
        /// </summary>
        public string? HaloDiameter { get; set; }

        /// <summary>
        /// پلی گروه A
        /// </summary>
        public string? PoliGroup_A { get; set; }

        /// <summary>
        /// پلی گروه B
        /// </summary>
        public string? PoliGroup_B { get; set; }

        /// <summary>
        /// پلی گروه C
        /// </summary>
        public string? PoliGroup_C { get; set; }

        /// <summary>
        /// پلی گروه D
        /// </summary>
        public string? PoliGroup_D { get; set; }
    }

    public class QCBaseInfoPhysicalSpecification : BaseEntity
    {
        public int QualityControlBaseInfoId { get; set; }
        [ForeignKey(nameof(QualityControlBaseInfoId))]
        public QualityControlBaseInfo QualityControlBaseInfo { get; set; }

        public string Title { get; set; }
        public bool IsChecked { get; set; }
    }
}
