using AutoMapper;
using Ecom.Api.HandleResponse;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Reposatories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductReposatory ProductReposatory, IMapper mapper, AppDBContext context , PhotoReposatory photoReposatory) : ControllerBase
    {

        [HttpGet("get-a-all-products")]
        public async Task<ActionResult> GetAllCAtegories()
        {
            var result = await ProductReposatory.GetAllAsync();
            if (result is not null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpGet("get-a-product/{id}")]
        public async Task<ActionResult> GetProductByIdAsync(int id)
        {
            var result = await ProductReposatory.GetById(id);
            var resultDTO = mapper.Map<ProductDTO>(result);
            if (result is not null)
                return Ok(resultDTO);
            else
                return BadRequest();
        }
        [HttpPost("add-product")]
        public async Task<ActionResult> AddProductAsync(AddProductDTO request)
        {
            var result = await ProductReposatory.Add(request);
            return result ? this.handleResponse(200 , returnData: result) : this.handleResponse(400);

        }
        [HttpPut("update-Product")]
        public async Task<ActionResult> AddProduct(UpdateProductDTO request)
        {
           var result =  await ProductReposatory.Update(request);
            return result ? this.handleResponse(200, returnData: result) : this.handleResponse(400);
        }
        [HttpPut("delete-product/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await ProductReposatory.Delete(id);
            return Ok();
        }
        [HttpGet("get-a-all-products-with-category-and-photos")]
        public async Task<ActionResult> GetAllProductsWithCategoryAndPhotos()
        {
            var result = await ProductReposatory.GetAllAsync(x => x.Category);
            var resultDto = mapper.Map<List<ProductDTO>>(result);
            if (result is not null)
                return Ok(resultDto);
            else
                return this.handleResponse(400);

        }
    }
}
