using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Services
{
    public interface IImageMangmentService
    {
        public Task<List<string>> AddImageAsync(IFormFileCollection images, string src);
        public void RemoveImage(string src);
    }
}
