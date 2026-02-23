using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class QualityControlBaseInfo : BaseEntity
    {
        public string Title { get; set; }
        public QualityControlPeriod QualityControlPeriod { get; set; }
        public int? DayIntervalCount { get; set; }
        public DateTime NextQualityControlTime { get; set; }
        public QCCategory Category { get; set; }

        public ICollection<StorageCondition> StorageConditions { get; set; }
        public ICollection<QCBaseInfoExpectedResult> QCBaseInfoExpectedResults { get; set; }
        public ICollection<QCBaseInfoPhysicalSpecification> QCBaseInfoPhysicalSpecifications { get; set; }
    }
}
