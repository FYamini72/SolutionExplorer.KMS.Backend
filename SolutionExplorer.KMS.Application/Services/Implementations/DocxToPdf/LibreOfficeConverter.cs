using SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf;
using System.Diagnostics;
using System.Text;

namespace SolutionExplorer.KMS.Application.Services.Implementations.DocxToPdf
{
    public class LibreOfficeConverter : ILibreOfficeConverter
    {
        private readonly string _sofficePath;
        public LibreOfficeConverter(string sofficePath = "soffice")
        {
            _sofficePath = sofficePath;
        }

        public void ConvertToPdf(string docxPath, string outputPdfPath, TimeSpan? timeout = null)
        {
            var outDir = Path.GetDirectoryName(outputPdfPath);
            Directory.CreateDirectory(outDir);

            var psi = new ProcessStartInfo
            {
                FileName = _sofficePath,
                Arguments = $"--headless --convert-to pdf \"{docxPath}\" --outdir \"{outDir}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            var sb = new StringBuilder();
            using (var p = Process.Start(psi))
            {
                if (p == null) throw new Exception("Could not start LibreOffice (soffice).");
                p.WaitForExit((int)(timeout?.TotalMilliseconds ?? 60000));
                sb.Append(p.StandardOutput.ReadToEnd());
                sb.Append(p.StandardError.ReadToEnd());

                if (p.ExitCode != 0)
                    throw new Exception($"LibreOffice conversion failed. ExitCode={p.ExitCode}. Output: {sb}");
            }

            var expectedPdf = Path.Combine(outDir, Path.GetFileNameWithoutExtension(docxPath) + ".pdf");
            if (!File.Exists(expectedPdf))
                throw new Exception("LibreOffice did not produce expected PDF file: " + expectedPdf);

            File.Move(expectedPdf, outputPdfPath, true);
        }
    }
}
