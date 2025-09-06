using SolutionExplorer.KMS.Domain.Enums;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class EventLogSearchDto : BaseSearchDto
    {
        public string? EntityName { get; set; }
        public string? EntityId { get; set; }
        public EventType? EventType { get; set; }
        public bool? HasError { get; set; }
        public string? IPAddress { get; set; }
        public string? Url { get; set; }
        public string? Method { get; set; }
    }
}