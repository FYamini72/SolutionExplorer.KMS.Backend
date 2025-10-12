using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class IdentifierDisplayDto : BaseDto
    {
        public string? Title { get; set; }
        public string? DocumentNumber { get; set; }
        public DocumentCategory Category { get; set; }
        public string? EditNo { get; set; }

        public int? ProducerUserId { get; set; }
        public string? ProducerUserFullName { get; set; }
        
        public int? FirstConfirmerUserId { get; set; }
        public string? FirstConfirmerUserFullName { get; set; }

        public int? SecondConfirmerUserId { get; set; }
        public string? SecondConfirmerUserFullName { get; set; }
    }
}