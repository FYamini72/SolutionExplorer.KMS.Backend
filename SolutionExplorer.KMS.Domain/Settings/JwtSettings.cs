namespace SolutionExplorer.KMS.Domain.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Encryptkey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
    }
    public class FilePathConfiguration
    {
        public string BasePath { get; set; }
        public string BaseUrl { get; set; }
        public string IdentifiersAttachmentPath { get; set; }
        public string ReferencesPath { get; set; }
        public bool IsProductionMode { get; set; }
    }
}
