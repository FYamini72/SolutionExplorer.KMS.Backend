using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PeriodicQualityControlCreateDto : BaseDto
    {
		public int QualityControlBaseInfoId { get; set; }
		public DateTime ManufactureDate { get; set; }
		public int PerformedByUserId { get; set; }
		public string? ManufacturerCompany { get; set; }
		public DateTime ProductionDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string? BatchNumber { get; set; }
		public DateTime OpeningDate { get; set; }
		public float PowderGramPerLiter { get; set; }
		public string? UsageStartAcceptanceNumber { get; set; }
		public MediumCountEnum MediumCount { get; set; }
		public StorageTemperatureEnum StorageTemperature { get; set; }
		public ShelfLifeDurationEnum ShelfLifeDuration { get; set; }
		public AutoclaveConditionEnum AutoclaveConditions { get; set; }
		public string? ExtraAutoclaveCondition { get; set; }
		public MediumTypeEnum MediumType { get; set; }
		public QualityControlPeriodEnum QualityControlPeriod { get; set; }
		public DateTime QualityControlDate { get; set; }
		public int FirstConfirmerUserId { get; set; }
		public int SecondConfirmerUserId { get; set; }

        public ICollection<PeriodicQCPhysicalSpecificationCreateDto> PhysicalSpecifications { get; set; }
        public ICollection<PeriodicQCAppearanceCreateDto> Appearances { get; set; }
    }

	public class PeriodicQCPhysicalSpecificationCreateDto : BaseDto
	{
        public int QCBaseInfoPhysicalSpecificationId { get; set; }
        //public int PeriodicQualityControlId { get; set; }
        public bool IsChecked { get; set; }
    }

    public class PeriodicQCAppearanceCreateDto : BaseDto
	{
        //public int PeriodicQualityControlId { get; set; }
        public int QCBaseInfoAppearanceId { get; set; }
    }

}