using Microsoft.AspNetCore.Http;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelUpdateDto : BaseDto
    {
        #region Fields Of User Table

        public string? Password { get; set; }
        public string? RePassword { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<int>? RoleIds { get; set; }
        public IFormFile? ProfileSelectedFile { get; set; }
        public IFormFile? SignatureSelectedFile { get; set; }

        #endregion

        public Prefix? Prefix { get; set; }
		public Gender? Gender { get; set; }
		public Position? Position { get; set; }
		public EducationalDegree? EducationalDegree { get; set; }
		public string? EducationalField { get; set; }
		public int? FirstConfirmerUserId { get; set; }
		public int? SecondConfirmerUserId { get; set; }
		public int? SuccessorUserId { get; set; }
		public string? OrganizationalChart { get; set; }

        public DateTime? EmploymentDate { get; set; }
        public string PersonnelNumber { get; set; }
    }
}