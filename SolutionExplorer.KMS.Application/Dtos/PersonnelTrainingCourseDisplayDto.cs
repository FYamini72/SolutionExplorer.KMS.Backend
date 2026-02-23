namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelTrainingCourseDisplayDto : BaseDto
    {
		public int PersonnelId { get; set; }
        public string PersonnelNumber { get; set; }
        public string? PersonnelFullName { get; set; }
        public string? Title { get; set; }
		public int Duration { get; set; }
		public string? TeacherFullName { get; set; }
		public DateTime DateOfEvent { get; set; }
		public int QualificationCriteria { get; set; }
		public int ScoreEarned { get; set; }
		public bool IsConfirmed { get; set; }
        public int? FirstConfirmerUserId { get; set; }
        public string? FirstConfirmerUserFullName { get; set; }

        public int? SecondConfirmerUserId { get; set; }
        public string? SecondConfirmerUserFullName { get; set; }

    }
}