using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PeriodicQualityControlSearchDto : BaseSearchDto
    {
        public int? QualityControlBaseInfoId { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public int? PerformedByUserId { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public MediumTypeEnum? MediumType { get; set; }
        public QualityControlPeriodEnum? QualityControlPeriod { get; set; }
        public DateTime? QualityControlDate { get; set; }
        public int? FirstConfirmerUserId { get; set; }
        public int? SecondConfirmerUserId { get; set; }
    }
}