using AutoMapper;
using Ecom.Api.HandleResponse;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Econ.Api.CategoryController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CategoryController(ICategoryReposatory CategoryReposatory, IMapper mapper) : ControllerBase
    {

        [HttpGet("get-a-all-categories")]
        public async Task<ActionResult> GetAllCAtegories()
        {
            var result = await CategoryReposatory.GetAllAsync();
            if (result is not null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpGet("get-a-category/{id}")]
        public async Task<ActionResult> GettegorYByIdAsync(int id)
        {
            var result = await CategoryReposatory.GetById(id);
            if (result is not null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpPost("add-category")]
        public async Task<ActionResult> AddCategoryAsync(CategoryDTO request)
        {
            var entity = new Category
            {
                Name = request.Name,
                Description = request.Description
            };
            await CategoryReposatory.Add(entity);
            return Ok();

        }
        [HttpPut("update-category")]
        public async Task<ActionResult> AddCategoryAsync(UpdateCategoryDTO request)
        {
            var entity = mapper.Map<Category>(request);
            await CategoryReposatory.Update(entity);
            return Ok();

        }
        [HttpPut("delete-category/{id}")]
        public async Task<ActionResult> DwlwtwCategory(int id)
        {
            await CategoryReposatory.Delete(id);
            return Ok();

        }
        //[HttpGet("get-a-all-categories-with-products")]
        //public async Task<ActionResult> GetAllCAtegoriesWithProducts()
        //{
        //    var result = await CategoryReposatory.GetAllAsync(x => x.Products);
        //    if (result is not null)
        //        return Ok(result);
        //    else
        //        return this.handleResponse(400);
        //}
    }
}