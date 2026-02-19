
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelColorBlindnessTestSearchDto : BaseSearchDto
    {
        public int? PersonnelId { get; set; }
        public DateTime? TestDate { get; set; }
        //public bool? RedColorDetection { get; set; }
        //public bool? BlueColorDetection { get; set; }
        //public bool? YellowColorDetection { get; set; }
        public int? IsConfirmed { get; set; }
    }
}