using IronOcr;

namespace Wortgitter.Controllers
{
    public interface IImageController 
    {
        public OcrResult ReadImage(IFormFile path);
    }
}
