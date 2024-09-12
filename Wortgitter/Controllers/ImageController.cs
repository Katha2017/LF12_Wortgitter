using IronOcr;
using Wortgitter.Services;

namespace Wortgitter.Controllers
{
    public class ImageController : IImageController
    {
        private readonly IImageService _imageService;
        
        public OcrResult ReadImage(string path)
        {
            OcrResult image = _imageService.ReadImage(path);
            OcrResult result = image;
            return result;
        }
    }
}
