using IronOcr;

namespace Wortgitter.Services
{
    public class ImageService
    {
        public OcrResult ReadImage(string path)
        {
            IronTesseract IronOcr = new IronTesseract();
            using (var input = new OcrInput(path))
            {
                var result = IronOcr.Read(input);
                result.SaveAsHtmlString(path, 200, true);
                return result;
            }
            ;
        }
    }
}
