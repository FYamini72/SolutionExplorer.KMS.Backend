using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.Dtos.AAA
{
    public class UserRoleSearchDto : BaseSearchDto
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public string? RoleTitle { get; set; }
    }
}