
namespace SolutionExplorer.KMS.Application.Dtos
{
    public class EquipmentCreateDto : BaseDto
    {
		public int? IdentifierId { get; set; }
		public string? Title { get; set; }
		public string? Code { get; set; }
		public string? EquipmentModel { get; set; }
		public string? SerialNo { get; set; }
		public string? Manufacturer { get; set; }
		public string? ManufactureCountry { get; set; }
		public int? FirstConfirmerUserId { get; set; }
		public int? SecondConfirmerUserId { get; set; }

    }
}