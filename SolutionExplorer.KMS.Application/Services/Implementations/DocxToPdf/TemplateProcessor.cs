using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using SolutionExplorer.KMS.Application.Dtos.DocxToPdf;
using SolutionExplorer.KMS.Application.Services.Interfaces.DocxToPdf;
using System.Drawing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace SolutionExplorer.KMS.Application.Services.Implementations.DocxToPdf
{
    public class TemplateProcessor : ITemplateProcessor
    {
        public void ProcessTemplate(string templateFilePath, string outputDocxPath, Dictionary<string, string> textReplacements, Dictionary<string, string> imageReplacements)
        {
            if (string.IsNullOrEmpty(templateFilePath)) throw new ArgumentNullException(nameof(templateFilePath));
            if (!File.Exists(templateFilePath)) throw new FileNotFoundException("Template file not found", templateFilePath);

            Directory.CreateDirectory(Path.GetDirectoryName(outputDocxPath) ?? Path.GetTempPath());
            File.Copy(templateFilePath, outputDocxPath, overwrite: true);

            using (var wordDoc = WordprocessingDocument.Open(outputDocxPath, true))
            {
                ReplaceInAllParts(wordDoc, textReplacements ?? new Dictionary<string, string>(), imageReplacements ?? new Dictionary<string, string>());
                wordDoc.MainDocumentPart.Document.Save();
            }
        }

        private void ReplaceInAllParts(WordprocessingDocument doc, Dictionary<string, string> textReplacements, Dictionary<string, string> imageReplacements)
        {
            var main = doc.MainDocumentPart;
            ReplaceInBody(main.Document.Body, main, textReplacements, imageReplacements);

            foreach (var headerPart in main.HeaderParts)
                ReplaceInBody(headerPart.Header, headerPart, textReplacements, imageReplacements);

            foreach (var footerPart in main.FooterParts)
                ReplaceInBody(footerPart.Footer, footerPart, textReplacements, imageReplacements);

            if (main.FootnotesPart?.Footnotes != null)
            {
                foreach (var footnote in main.FootnotesPart.Footnotes.Elements<Footnote>())
                    foreach (var para in footnote.Descendants<Paragraph>())
                        ReplaceInParagraph(para, main.FootnotesPart, textReplacements, imageReplacements);
            }

            if (main.EndnotesPart?.Endnotes != null)
            {
                foreach (var endnote in main.EndnotesPart.Endnotes.Elements<Endnote>())
                    foreach (var para in endnote.Descendants<Paragraph>())
                        ReplaceInParagraph(para, main.EndnotesPart, textReplacements, imageReplacements);
            }

            if (main.WordprocessingCommentsPart?.Comments != null)
            {
                foreach (var comment in main.WordprocessingCommentsPart.Comments.Elements<Comment>())
                    foreach (var para in comment.Descendants<Paragraph>())
                        ReplaceInParagraph(para, main.WordprocessingCommentsPart, textReplacements, imageReplacements);
            }
        }

        private void ReplaceInBody(OpenXmlElement bodyOrHeaderFooter, OpenXmlPart owningPart, Dictionary<string, string> textReplacements, Dictionary<string, string> imageReplacements)
        {
            foreach (var para in bodyOrHeaderFooter.Descendants<Paragraph>())
                ReplaceInParagraph(para, owningPart, textReplacements, imageReplacements);
        }

        private void ReplaceInParagraph(Paragraph paragraph, OpenXmlPart owningPart, Dictionary<string, string> textReplacements, Dictionary<string, string> imageReplacements)
        {
            var runs = paragraph.Elements<Run>().ToList();
            if (!runs.Any()) return;

            var pieces = runs.Select(r => new RunPieceDto
            {
                Run = r,
                TextElement = r.GetFirstChild<Text>(),
                Text = r.GetFirstChild<Text>()?.Text ?? ""
            }).ToList();

            string concat = string.Concat(pieces.Select(p => p.Text));

            // تصاویر اول
            foreach (var kv in imageReplacements)
            {
                var token = $"{{{{{kv.Key}}}}}";
                int idx = concat.IndexOf(token, StringComparison.Ordinal);
                while (idx >= 0)
                {
                    ReplaceTokenWithImage(paragraph, pieces, idx, token.Length, kv.Value, owningPart);
                    runs = paragraph.Elements<Run>().ToList();
                    pieces = runs.Select(r => new RunPieceDto { Run = r, TextElement = r.GetFirstChild<Text>(), Text = r.GetFirstChild<Text>()?.Text ?? "" }).ToList();
                    concat = string.Concat(pieces.Select(p => p.Text));
                    idx = concat.IndexOf(token, StringComparison.Ordinal);
                }
            }

            // سپس متن
            foreach (var kv in textReplacements)
            {
                var token = $"{{{{{kv.Key}}}}}";
                int idx = concat.IndexOf(token, StringComparison.Ordinal);
                while (idx >= 0)
                {
                    ReplaceTokenWithText(paragraph, pieces, idx, token.Length, kv.Value);
                    runs = paragraph.Elements<Run>().ToList();
                    pieces = runs.Select(r => new RunPieceDto { Run = r, TextElement = r.GetFirstChild<Text>(), Text = r.GetFirstChild<Text>()?.Text ?? "" }).ToList();
                    concat = string.Concat(pieces.Select(p => p.Text));
                    idx = concat.IndexOf(token, StringComparison.Ordinal);
                }
            }
        }

        private void ReplaceTokenWithText(Paragraph paragraph, List<RunPieceDto> pieces, int tokenStartIndex, int tokenLength, string replacementText)
        {
            int acc = 0;
            int startRun = -1, startOffset = 0;
            for (int i = 0; i < pieces.Count; i++)
            {
                var len = pieces[i].Text.Length;
                if (acc + len > tokenStartIndex)
                {
                    startRun = i;
                    startOffset = tokenStartIndex - acc;
                    break;
                }
                acc += len;
            }
            if (startRun == -1) return;

            int tokenEnd = tokenStartIndex + tokenLength;
            acc = 0;
            int endRun = -1, endOffset = 0;
            for (int i = 0; i < pieces.Count; i++)
            {
                var len = pieces[i].Text.Length;
                if (acc + len >= tokenEnd)
                {
                    endRun = i;
                    endOffset = tokenEnd - acc;
                    break;
                }
                acc += len;
            }
            if (endRun == -1) return;

            var newRuns = new List<Run>();
            for (int i = 0; i < startRun; i++) newRuns.Add(CloneRunWithText(pieces[i].Run, pieces[i].Text));
            if (startOffset > 0)
            {
                var before = pieces[startRun].Text.Substring(0, startOffset);
                newRuns.Add(CloneRunWithText(pieces[startRun].Run, before));
            }
            newRuns.Add(CloneRunWithText(pieces[startRun].Run, replacementText));
            if (endOffset < pieces[endRun].Text.Length)
            {
                var after = pieces[endRun].Text.Substring(endOffset);
                newRuns.Add(CloneRunWithText(pieces[endRun].Run, after));
            }
            for (int i = endRun + 1; i < pieces.Count; i++) newRuns.Add(CloneRunWithText(pieces[i].Run, pieces[i].Text));

            paragraph.RemoveAllChildren<Run>();
            foreach (var r in newRuns) paragraph.AppendChild(r);
        }

        private void ReplaceTokenWithImage(Paragraph paragraph, List<RunPieceDto> pieces, int tokenStartIndex, int tokenLength, string imageFilePath, OpenXmlPart owningPart)
        {
            int acc = 0;
            int startRun = -1, startOffset = 0;
            for (int i = 0; i < pieces.Count; i++)
            {
                var len = pieces[i].Text.Length;
                if (acc + len > tokenStartIndex)
                {
                    startRun = i;
                    startOffset = tokenStartIndex - acc;
                    break;
                }
                acc += len;
            }
            if (startRun == -1) return;

            int tokenEnd = tokenStartIndex + tokenLength;
            acc = 0;
            int endRun = -1, endOffset = 0;
            for (int i = 0; i < pieces.Count; i++)
            {
                var len = pieces[i].Text.Length;
                if (acc + len >= tokenEnd)
                {
                    endRun = i;
                    endOffset = tokenEnd - acc;
                    break;
                }
                acc += len;
            }
            if (endRun == -1) return;

            var newRuns = new List<Run>();
            for (int i = 0; i < startRun; i++) newRuns.Add(CloneRunWithText(pieces[i].Run, pieces[i].Text));
            if (startOffset > 0)
            {
                var before = pieces[startRun].Text.Substring(0, startOffset);
                newRuns.Add(CloneRunWithText(pieces[startRun].Run, before));
            }

            var imageRun = CreateImageRun(owningPart, imageFilePath, 150, 80);
            if (imageRun != null) newRuns.Add(imageRun);

            if (endOffset < pieces[endRun].Text.Length)
            {
                var after = pieces[endRun].Text.Substring(endOffset);
                newRuns.Add(CloneRunWithText(pieces[endRun].Run, after));
            }
            for (int i = endRun + 1; i < pieces.Count; i++) newRuns.Add(CloneRunWithText(pieces[i].Run, pieces[i].Text));

            paragraph.RemoveAllChildren<Run>();
            foreach (var r in newRuns) paragraph.AppendChild(r);
        }

        private Run CloneRunWithText(Run sourceRun, string newText)
        {
            var r = new Run();
            if (sourceRun.RunProperties != null)
                r.RunProperties = (RunProperties)sourceRun.RunProperties.CloneNode(true);

            var t = new Text(newText ?? "") { Space = SpaceProcessingModeValues.Preserve };
            r.AppendChild(t);
            return r;
        }

        private Run CreateImageRun(OpenXmlPart owningPart, string imageFilePath, int? widthPx = null, int? heightPx = null)
        {
            try
            {
                if (string.IsNullOrEmpty(imageFilePath) || !File.Exists(imageFilePath)) return null;
                var partType = GetImagePartType(imageFilePath);

                int pxW = widthPx ?? 200;
                int pxH = heightPx ?? 100;
                if (widthPx == null || heightPx == null)
                {
                    try
                    {
                        using (var img = Image.FromFile(imageFilePath))
                        {
                            pxW = widthPx ?? img.Width;
                            pxH = heightPx ?? img.Height;
                        }
                    }
                    catch { }
                }

                ImagePart imagePart = null;
                OpenXmlPart partWithImageId = null;

                if (owningPart is HeaderPart headerPart)
                {
                    imagePart = headerPart.AddImagePart(partType);
                    partWithImageId = headerPart;
                }
                else if (owningPart is FooterPart footerPart)
                {
                    imagePart = footerPart.AddImagePart(partType);
                    partWithImageId = footerPart;
                }
                else
                {
                    var mainPart = GetMainDocumentPartFromPart(owningPart) ??
                                   owningPart.OpenXmlPackage?.Parts.OfType<IdPartPair>()
                                       .FirstOrDefault()?.OpenXmlPart as MainDocumentPart;

                    if (mainPart != null)
                    {
                        imagePart = mainPart.AddImagePart(partType);
                        partWithImageId = mainPart;
                    }
                    else
                    {
                        return null;
                    }
                }

                using (var fs = File.OpenRead(imageFilePath))
                    imagePart.FeedData(fs);

                string relId = partWithImageId.GetIdOfPart(imagePart);

                long cx = (long)(pxW * 9525L);
                long cy = (long)(pxH * 9525L);

                var drawing = GetImageDrawing(relId, Path.GetFileName(imageFilePath), cx, cy);
                return new Run(drawing);
            }
            catch { return null; }
        }

        private MainDocumentPart GetMainDocumentPartFromPart(OpenXmlPart part)
        {
            if (part == null) return null;
            var pkg = part.OpenXmlPackage as WordprocessingDocument;
            return pkg?.MainDocumentPart;
        }

        private static ImagePartType GetImagePartType(string fileName)
        {
            var ext = Path.GetExtension(fileName ?? "").ToLowerInvariant();
            return ext switch
            {
                ".png" => ImagePartType.Png,
                ".jpg" or ".jpeg" => ImagePartType.Jpeg,
                ".gif" => ImagePartType.Gif,
                ".bmp" => ImagePartType.Bmp,
                ".tiff" or ".tif" => ImagePartType.Tiff,
                _ => ImagePartType.Jpeg
            };
        }

        private Drawing GetImageDrawing(string relationshipId, string fileName, long cx, long cy)
        {
            var element =
              new Drawing(
                new DW.Inline(
                  new DW.Extent() { Cx = cx, Cy = cy },
                  new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                  new DW.DocProperties() { Id = (UInt32Value)1U, Name = fileName ?? "Picture" },
                  new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }),
                  new A.Graphic(
                    new A.GraphicData(
                      new PIC.Picture(
                        new PIC.NonVisualPictureProperties(
                          new PIC.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = fileName ?? "Image.jpg" },
                          new PIC.NonVisualPictureDrawingProperties()
                        ),
                        new PIC.BlipFill(
                          new A.Blip() { Embed = relationshipId },
                          new A.Stretch(new A.FillRectangle())
                        ),
                        new PIC.ShapeProperties(
                          new A.Transform2D(
                            new A.Offset() { X = 0L, Y = 0L },
                            new A.Extents() { Cx = cx, Cy = cy }
                          ),
                          new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle }
                        )
                      )
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                  )
                )
              );
            return element;
        }
    }
}
