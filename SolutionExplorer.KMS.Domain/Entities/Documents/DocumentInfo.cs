namespace SolutionExplorer.KMS.Domain.Entities.Documents
{
    public class DocumentInfo : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string FileName { get; set; }

        public string LabName { get; set; }
        public string EditNumber { get; set; }
        public string EditDate { get; set; }
        public string ReviewDate { get; set; }
        public string ConfirmerOneName { get; set; }
        public string ConfirmerOneSignImage { get; set; }
        public string ConfirmerTwoName { get; set; }
        public string ConfirmerTwoSignImage { get; set; }
    }
}
