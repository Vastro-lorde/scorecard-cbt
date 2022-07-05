using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using scorecard_cbt.Interfaces;
using scorecard_cbt.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary cloudinary;
        public ImageService(IConfiguration configuration, ImageUploadSettings imageUploadSettings)
        {
            _configuration = configuration;
            cloudinary = new Cloudinary(new Account(
                imageUploadSettings.CloudName,
                imageUploadSettings.ApiKey,
                imageUploadSettings.ApiSecret));
        }
        public async Task<UploadResult> UploadAsync(IFormFile image)
        {
            var pictureSize = Convert.ToInt64(_configuration.GetSection(ImageServiceFeedBacks.photoSettings).Get<string>());
            if (image.Length > pictureSize)
            {
                throw new ArgumentException(ImageServiceFeedBacks.sizeExceeded);
            }

            var pictureFormat = false;
            var listOfImageExtensions = _configuration.GetSection(ImageServiceFeedBacks.photoFormat).Get<List<string>>();
            foreach (var item in listOfImageExtensions)
            {
                if (image.FileName.EndsWith(item))
                {
                    pictureFormat = true;
                    break;
                }
            }

            if (pictureFormat == false)
            {
                throw new ArgumentException(ImageServiceFeedBacks.unsupportedFormat);
            }

            var uploadResult = new ImageUploadResult();

            //fetch the image using image stream
            using (var imageStream = image.OpenReadStream())
            {
                string fileName = Guid.NewGuid().ToString() + image.FileName;
                uploadResult = await cloudinary.UploadAsync(new ImageUploadParams()
                {
                    File = new FileDescription(fileName, imageStream),
                    Transformation = new Transformation().Crop(ImageServiceFeedBacks.crop).Gravity(ImageServiceFeedBacks.gravity).Width(1000).Height(1000).Radius(40)
                });
            }
            return uploadResult;
        }
    }
}
