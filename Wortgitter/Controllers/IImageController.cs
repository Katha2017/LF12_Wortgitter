using IronOcr;
using Microsoft.AspNetCore.Mvc;

namespace Wortgitter.Controllers
{
    public interface IImageController
    {
        public OcrResult ReadImage(string path);
    }
}
