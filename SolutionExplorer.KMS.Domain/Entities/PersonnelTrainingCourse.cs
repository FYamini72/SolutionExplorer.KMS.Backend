using SolutionExplorer.KMS.Domain.Entities.AAA;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionExplorer.KMS.Domain.Entities
{
    public class PersonnelTrainingCourse : BaseEntity
    {
        public int PersonnelId { get; set; }
        [ForeignKey(nameof(PersonnelId))]
        public Personnel Personnel { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// مدت دوره (ساعت)
        /// </summary>
        public int Duration { get; set; }

        public string TeacherFullName { get; set; }

        public DateTime DateOfEvent { get; set; }

        /// <summary>
        /// معیار صلاحیت نمره بین 60 تا 100
        /// </summary>
        public int QualificationCriteria { get; set; }

        /// <summary>
        /// نمره کسب شده بین 0 تا 100
        /// </summary>
        public int ScoreEarned { get; set; }

        public bool IsConfirmed { get; set; }

        public int FirstConfirmerUserId { get; set; }
        [ForeignKey(nameof(FirstConfirmerUserId))]
        public User FirstConfirmerUser { get; set; }

        public int SecondConfirmerUserId { get; set; }
        [ForeignKey(nameof(SecondConfirmerUserId))]
        public User SecondConfirmerUser { get; set; }
    }
}
