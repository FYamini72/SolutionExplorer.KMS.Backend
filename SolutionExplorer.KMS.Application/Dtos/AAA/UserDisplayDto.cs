namespace SolutionExplorer.KMS.Application.Dtos.AAA
{
    public class UserDisplayDto : BaseDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<UserRoleDisplayDto> UserRoles { get; set; }


        public int? ProfileId { get; set; }
        public string? ProfileAttachmentUrl { get; set; }

        public int? SignatureId { get; set; }
        public string? SignatureAttachmentUrl { get; set; }
    }
}
