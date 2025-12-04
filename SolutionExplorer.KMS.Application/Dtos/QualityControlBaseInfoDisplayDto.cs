using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class QualityControlBaseInfoDisplayDto : BaseDto
    {
		public string? Title { get; set; }
		//public string? Manufacturer { get; set; }
		//public string? Series { get; set; }
		//public DateTime ProductionDate { get; set; }
		//public DateTime ExpirationDate { get; set; }

        public QualityControlPeriod QualityControlPeriod { get; set; }
        public int? DayIntervalCount { get; set; }
        public DateTime NextQualityControlTime { get; set; }
        //public string? DefaultValue { get; set; }
        public QCCategory Category { get; set; }

        public List<StorageConditionDisplayDto> StorageConditions { get; set; } = new();
        public List<QCBaseInfoExpectedResultDisplayDto> QCBaseInfoExpectedResults { get; set; } = new();
        public List<QCBaseInfoPhysicalSpecificationDisplayDto> QCBaseInfoPhysicalSpecifications { get; set; } = new();
    }
}