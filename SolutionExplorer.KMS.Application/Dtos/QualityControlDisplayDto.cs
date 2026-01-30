
using SolutionExplorer.KMS.Domain.Entities;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class QualityControlDisplayDto : BaseDto
    {
        public int QualityControlBaseInfoId { get; set; }

        public string Produces { get; set; }
        public DateTime SampleDate { get; set; }
        public string? Title { get; set; }
		public string? Manufacturer { get; set; }
		public string? Series { get; set; }
		public DateTime ProductionDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		
        public int? StorageConditionId { get; set; }
        public string? StorageConditionTitle { get; set; }

        public int? PerformedByUserId { get; set; }
        public string? PerformedByUserFullName { get; set; }

        public int FirstConfirmerUserId { get; set; }
        public string FirstConfirmerUserFullName { get; set; }

        public int SecondConfirmerUserId { get; set; }
        public string SecondConfirmerUserFullName { get; set; }

        public bool IsConfirmed { get; set; }

        public List<PhysicalSpecificationDisplayDto> PhysicalSpecifications { get; set; }
        public List<QualityControlResultDisplayDto> QualityControlResults { get; set; }

    }
}