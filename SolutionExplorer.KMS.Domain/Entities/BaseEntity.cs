using System.ComponentModel.DataAnnotations.Schema;
using SolutionExplorer.KMS.Domain.Entities.AAA;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedByUserId { get; set; }
        [ForeignKey(nameof(CreatedByUserId))]
        public User? CreatedByUser { get; set; }

        public int? ModifiedByUserId { get; set; }
        [ForeignKey(nameof(ModifiedByUserId))]
        public User? ModifiedByUser { get; set; }
    }
}
