using Microsoft.AspNetCore.Http;

namespace SolutionExplorer.KMS.Application.Dtos
{
    public class IdentifierChangeFileAndDescriptionDto : BaseDto
    {
        public string? Description { get; set; }

        public IFormFile? SelectedFile { get; set; }
    }
}