using SolutionExplorer.KMS.Domain.Entities.AAA;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class PersonnelColorBlindnessTest : BaseEntity
    {
        public int PersonnelId { get; set; }
        [ForeignKey(nameof(PersonnelId))]
        public Personnel Personnel { get; set; }

        public DateTime TestDate { get; set; }

        public bool RedColorDetection { get; set; }                                                                                                                                                                                                                                                                            
        public bool BlueColorDetection { get; set; }                                                                                                                                                                                                                                                                            
        public bool YellowColorDetection { get; set; }

        public bool IsConfirmed { get; set; }

        public int FirstConfirmerUserId { get; set; }
        [ForeignKey(nameof(FirstConfirmerUserId))]
        public User FirstConfirmerUser { get; set; }

        public int SecondConfirmerUserId { get; set; }
        [ForeignKey(nameof(SecondConfirmerUserId))]
        public User SecondConfirmerUser { get; set; }

    }
}
