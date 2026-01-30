
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class QualityControlBaseInfoSearchDto : BaseSearchDto
    {
        public string? Title { get; set; }
        //public string? Manufacturer { get; set; }
        //public string? Series { get; set; }
        //public DateTime? ProductionDate { get; set; }
        //public DateTime? ExpirationDate { get; set; }

        public QualityControlPeriod? QualityControlPeriod { get; set; }
        public int? DayIntervalCount { get; set; }
        public DateTime? FromNextQualityControlTime { get; set; }
        public DateTime? ToNextQualityControlTime { get; set; }

        public QCCategory? Category { get; set; }
    }
}