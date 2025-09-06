namespace SolutionExplorer.KMS.Application.Dtos.AAA
{
    public class UserSearchDto : BaseSearchDto
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }
    }
}
