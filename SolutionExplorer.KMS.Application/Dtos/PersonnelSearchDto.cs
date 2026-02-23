using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelSearchDto : BaseSearchDto
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }

        public Prefix? Prefix { get; set; }
        public Gender? Gender { get; set; }
        public Position? Position { get; set; }
        public EducationalDegree? EducationalDegree { get; set; }
        public string? EducationalField { get; set; }
        public int? FirstConfirmerUserId { get; set; }
        public int? SecondConfirmerUserId { get; set; }
        public int? SuccessorUserId { get; set; }
        public string? PersonnelNumber { get; set; }
    }
}