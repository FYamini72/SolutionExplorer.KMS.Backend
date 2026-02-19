
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelColorBlindnessTestDisplayDto : BaseDto
    {
		public int PersonnelId { get; set; }

        public DateTime? EmploymentDate { get; set; }
        public string PersonnelNumber { get; set; }
        public Prefix Prefix { get; set; }
        public string? PersonnelFullName { get; set; }

        public DateTime TestDate { get; set; }
		public bool RedColorDetection { get; set; }
		public bool BlueColorDetection { get; set; }
		public bool YellowColorDetection { get; set; }
		public bool IsConfirmed { get; set; }

        public int? FirstConfirmerUserId { get; set; }
        public string? FirstConfirmerUserFullName { get; set; }

        public int? SecondConfirmerUserId { get; set; }
        public string? SecondConfirmerUserFullName { get; set; }
    }
}