using IronOcr;
using Microsoft.AspNetCore.Mvc;
using Wortgitter.Services;
using Wortgitter.Controllers;
using Microsoft.AspNetCore.Authorization;
namespace Wortgitter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [AllowAnonymous]
        public OcrResult ReadImage(IFormFile file)
        {
            string path = "";
            OcrResult textFile = _imageService.ReadImage(path);
            OcrResult result = textFile;
            return result;
        }
    }
}
