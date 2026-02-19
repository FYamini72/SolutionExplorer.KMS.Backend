
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelTrainingCourseSearchDto : BaseSearchDto
    {
        public int? PersonnelId { get; set; }
        public int? IsConfirmed { get; set; }
    }
}