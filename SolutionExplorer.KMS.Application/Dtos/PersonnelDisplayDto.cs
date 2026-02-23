using SolutionExplorer.KMS.Application.Dtos.AAA;
using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class PersonnelDisplayDto : BaseDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<UserRoleDisplayDto> UserRoles { get; set; }

        public List<int>? RoleIds { get; set; }


        public int? ProfileId { get; set; }
        public string? ProfileAttachmentUrl { get; set; }

        public int? SignatureId { get; set; }
        public string? SignatureAttachmentUrl { get; set; }


        public Prefix Prefix { get; set; }
		public Gender Gender { get; set; }
		public Position Position { get; set; }
		public EducationalDegree EducationalDegree { get; set; }
		public string? EducationalField { get; set; }
        public int? FirstConfirmerUserId { get; set; }
        public string? FirstConfirmerUserFullName { get; set; }

        public int? SecondConfirmerUserId { get; set; }
        public string? SecondConfirmerUserFullName { get; set; }

        public int? SuccessorUserId { get; set; }
        public string? SuccessorUserFullName { get; set; }

		public string? OrganizationalChart { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string PersonnelNumber { get; set; }
    }
}