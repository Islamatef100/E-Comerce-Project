using Ecom.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Reposatories.Services
{
    public class ImageMangmentService : IImageMangmentService
    {
        private readonly IFileProvider fileProvider;
        public ImageMangmentService(IFileProvider _fileProvider) {
            fileProvider = _fileProvider;
        }

        public async Task<List<string>> AddImageAsync(IFormFileCollection images, string src)
        {
            var imagesPathes = new List<string>();
            var ImagePath = Path.Combine("wwwroot", "Images", src);
            
            var isDirectoryExist = Directory.Exists(ImagePath);
            if (!isDirectoryExist)
                Directory.CreateDirectory(ImagePath);
            foreach (var image in images)
            {
                var path = Path.Combine("Images", image.Name);
                var FullImagePath = Path.Combine(ImagePath, image.FileName);
                using (var fileStream = new FileStream(FullImagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                };
                imagesPathes.Add(path);
            }
            return imagesPathes;
        }

        public void RemoveImage(string src)
        {
            var file = fileProvider.GetFileInfo(src).PhysicalPath;
            if (File.Exists(src))
                File.Delete(file);

        }
    }
}
