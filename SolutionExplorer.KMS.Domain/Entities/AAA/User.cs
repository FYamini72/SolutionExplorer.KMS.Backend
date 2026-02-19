using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities.AAA
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? ProfileId { get; set; }
        [ForeignKey(nameof(ProfileId))]
        public AttachmentFile? Profile { get; set; }

        public int? SignatureId { get; set; }
        [ForeignKey(nameof(SignatureId))]
        public AttachmentFile? Signature { get; set; }

        public Guid SecurityStamp { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
