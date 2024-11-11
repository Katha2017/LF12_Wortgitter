using IronOcr;
using Microsoft.AspNetCore.Mvc;
using Wortgitter.Services;

namespace Wortgitter.Controllers
{
    [Controller]
    public class ImageController : IImageController
    {
        private readonly IImageService _imageService;

        [HttpPost]
        public OcrResult ReadImage(string path)
        {
            OcrResult image = _imageService.ReadImage(path);
            OcrResult result = image;
            return result;
        }
    }
}
