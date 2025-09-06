using SolutionExplorer.KMS.Application.Dtos;

namespace SolutionExplorer.KMS.Application.Dtos.AAA
{
    public class UserRoleCreateDto : BaseDto
    {
		public int UserId { get; set; }
		public int RoleId { get; set; }

    }
}