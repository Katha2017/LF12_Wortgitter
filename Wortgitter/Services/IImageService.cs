using IronOcr;

namespace Wortgitter.Services
{
    public interface IImageService
    {
        public OcrResult ReadImage(string path);
    }
}
