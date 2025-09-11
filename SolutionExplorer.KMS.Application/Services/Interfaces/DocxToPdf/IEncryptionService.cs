namespace SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf
{
    public interface IEncryptionService
    {
        byte[] EncryptAes(byte[] plainBytes);
    }
}
