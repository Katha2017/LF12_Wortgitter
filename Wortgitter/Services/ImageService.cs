using IronOcr;
using IronSoftware;

namespace Wortgitter.Services
{
    public class ImageService
    {
        public OcrResult ReadImage(string path)
        {
            IronTesseract IronOcr = new IronTesseract();
            OcrResult Result = IronOcr.Read(path);
            return Result;
            ;
        }
    }
}
