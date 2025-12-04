
using SolutionExplorer.KMS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class QualityControlCreateDto : BaseDto
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

		public int? PerformedByUserId { get; set; }
		public int FirstConfirmerUserId { get; set; }
		public int SecondConfirmerUserId { get; set; }
        public bool IsConfirmed { get; set; }

        public List<QualityControlResultCreateDto> QualityControlResults { get; set; }
        public List<PhysicalSpecificationCreateDto> PhysicalSpecifications { get; set; }
    }

	public class QualityControlResultCreateDto : BaseDto
    {
        public int QCBaseInfoExpectedResultId { get; set; }
        public int QualityControlId { get; set; }
        public bool IsConfirmed { get; set; }
        public string? CorrectiveActions { get; set; }
    }

	public class QualityControlResultDisplayDto : BaseDto
    {
        public int QCBaseInfoExpectedResultId { get; set; }
        public QCBaseInfoExpectedResultDisplayDto QCBaseInfoExpectedResult { get; set; }
        public int QualityControlId { get; set; }
        public bool IsConfirmed { get; set; }
        public string? CorrectiveActions { get; set; }
    }

    public class PhysicalSpecificationCreateDto : BaseDto
    {
        public int QCBaseInfoPhysicalSpecificationId { get; set; }
        public int QualityControlId { get; set; }
        public bool IsChecked { get; set; }
    }

    public class PhysicalSpecificationDisplayDto : BaseDto
    {
        public int QCBaseInfoPhysicalSpecificationId { get; set; }
        public string QCBaseInfoPhysicalSpecificationTitle { get; set; }
        public int QualityControlId { get; set; }
        public bool IsChecked { get; set; }
    }
}