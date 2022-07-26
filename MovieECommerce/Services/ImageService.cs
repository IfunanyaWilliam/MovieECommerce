using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using MovieECommerce.Contract;

namespace MovieECommerce.Services
{
    public class ImageService : IImageService
    {
        private readonly CloudinaryConfiguration _config;

        //The IOptions is injected via the constructor to map the configuration to the ImageService
        public ImageService(IOptions<CloudinaryConfiguration> config)
        {
            _config = config.Value;
        }

        public async Task<string> UploadImage(string path)
        {

            var myAccount = new Account { ApiKey = _config.ApiKey, ApiSecret = _config.ApiSecret, Cloud = _config.Name };
            Cloudinary _cloudinary = new(myAccount);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.Url.AbsoluteUri;

        }

    }
}
