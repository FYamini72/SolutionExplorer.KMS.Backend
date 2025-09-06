using Microsoft.AspNetCore.Http;

namespace SolutionExplorer.KMS.Application.Dtos.AAA
{
    public class UserUpdateDto : BaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? NewPassword { get; set; }

        public IFormFile? SelectedFile { get; set; }
    }
}