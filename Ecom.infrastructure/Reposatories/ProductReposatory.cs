using AutoMapper;
using Azure.Core;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Reposatories
{
    public class ProductReposatory : GenericReposatory<Product> , IProductReposatory
    {
        private readonly IMapper mapper;
        private readonly AppDBContext dbbContext;
        private readonly IImageMangmentService ImageService;

        //            var paths = await ImageService.AddImageAsync(request.Photos,"test");
        public ProductReposatory(AppDBContext _context, IMapper _mapper , IImageMangmentService _imageService) : base(_context) 
        {
            dbbContext = _context;
            mapper = _mapper;
            ImageService = _imageService;
        }

        public async Task<bool> Add(AddProductDTO request)
        {
            if (request is null) return false;
            var product = mapper.Map<Product>(request);
            dbbContext.Set<Product>().Add(product);
            await dbbContext.SaveChangesAsync();
            var pathes = await ImageService.AddImageAsync(request.Photos, request.name);
            dbbContext.Set<Photo>().AddRange(request.Photos.Select(x => new Photo
            {
                ImageName = Path.Combine("Images",request.name, x.FileName),
                ProductId = product.Id,
            }));
            await dbbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(UpdateProductDTO request)
        {
            if (request is null) return false;
            var product = mapper.Map<Product>(request);
            dbbContext.Set<Product>().Update(product);
            await dbbContext.SaveChangesAsync();
            var photos = await dbbContext.Set<Photo>().Where(x => x.ProductId == product.Id).ToListAsync();
   
            if (photos.Count > 0)
            {
                foreach (var item in photos)
                {
                    //var path = Path.Combine("wwwroot", "Images", "test", item.ImageName);
                     ImageService.RemoveImage(item.ImageName);
                }
                dbbContext.Set<Photo>().RemoveRange(photos);
            }    

            var pathes = await ImageService.AddImageAsync(request.Photos, request.name);
            dbbContext.Set<Photo>().AddRange(request.Photos.Select(x => new Photo
            {
                ImageName = x.FileName,
                ProductId = product.Id,
            }));
            await dbbContext.SaveChangesAsync();
            return true;
        }
    }
}
