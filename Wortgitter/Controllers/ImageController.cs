using IronOcr;
using Microsoft.AspNetCore.Mvc;
using Wortgitter.Services;

namespace Wortgitter.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ImageController : ControllerBase, IImageController
    {

        private readonly IImageService _imageService;

    [HttpPost("string")]
    public OcrResult ReadImage(string path)
        {
            OcrResult image = _imageService.ReadImage(path);
            OcrResult result = image;
            return result;
        }
    }
}
