using System.ComponentModel.DataAnnotations;

namespace SolutionExplorer.KMS.Domain.Enums
{
    /// <summary>
    /// مقطع تحصیلی پرسنل
    /// </summary>
    public enum EducationalDegree
    {
        [Display(Name = "بدون مدرک")]
        None,

        [Display(Name = "دیپلم")]
        Diploma,

        [Display(Name = "فوق دیپلم")]
        AssociateDegree,

        [Display(Name = "لیسانس")]
        Bachelors,

        [Display(Name = "فوق لیسانس")]
        Masters,

        [Display(Name = "دکتری")]
        PhD
    }
}
