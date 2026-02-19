
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelTrainingCourseCreateDto : BaseDto
    {
		public int PersonnelId { get; set; }
		public string? Title { get; set; }
		public int? Duration { get; set; }
		public string? TeacherFullName { get; set; }
		public DateTime DateOfEvent { get; set; }
		public int? QualificationCriteria { get; set; }
		public int? ScoreEarned { get; set; }
		public bool IsConfirmed { get; set; }
		public int? FirstConfirmerUserId { get; set; }
		public int? SecondConfirmerUserId { get; set; }

    }
}