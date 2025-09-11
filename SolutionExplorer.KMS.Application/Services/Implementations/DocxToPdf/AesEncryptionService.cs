using SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf;
using System.Security.Cryptography;
using System.Text;

namespace SolutionExplorer.KMS.Application.Services.Implementations.DocxToPdf
{
    public class AesEncryptionService : IEncryptionService
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("MySecretKey12345"); // 16 بایتی (AES-128)
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("MySecretIV123456");  // 16 بایتی

        public byte[] EncryptAes(byte[] plainBytes)
        {
            if (plainBytes == null) throw new ArgumentNullException(nameof(plainBytes));
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
                cs.FlushFinalBlock();
            }
            return ms.ToArray();
        }
    }
}
