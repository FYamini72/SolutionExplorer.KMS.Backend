
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelColorBlindnessTestCreateDto : BaseDto
    {
		public int PersonnelId { get; set; }
		public DateTime TestDate { get; set; }
		public bool RedColorDetection { get; set; }
		public bool BlueColorDetection { get; set; }
		public bool YellowColorDetection { get; set; }
		public bool IsConfirmed { get; set; }
        public int? FirstConfirmerUserId { get; set; }
        public int? SecondConfirmerUserId { get; set; }
    }
}