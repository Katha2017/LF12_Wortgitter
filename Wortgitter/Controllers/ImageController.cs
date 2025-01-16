using IronOcr;
using Microsoft.AspNetCore.Mvc;
using Wortgitter.Services;
using Wortgitter.Controllers;
namespace Wortgitter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase, IImageController
    {
        private readonly IImageService _imageService;

        [HttpPost]
        public OcrResult ReadImage(string path)
        {
            OcrResult textFile = _imageService.ReadImage(path);
            OcrResult result = textFile;
            return result;
        }
    }
}
