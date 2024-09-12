using IronOcr;

namespace Wortgitter.Controllers
{
    public interface IImageController
    {
        public OcrResult ReadImage(string path);
    }
}
