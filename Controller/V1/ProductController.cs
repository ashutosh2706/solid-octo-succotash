using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data.Service;
using MyApi.Data.Model;

namespace MyApi.Controller.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prods = await _productService.GetAllProds();
            return Ok(prods);
        }

        [HttpPost]
        public async Task<IActionResult> AddProd(Product product)
        {
            await _productService.Add(product);
            return Created("api/product", new
            {
                code = 201,
                message = "Product added successfully"
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> DeleteProd(long id)
        {
            
            var prod = await _productService.GetProd(id);
            if (prod == null)
            {
                return NotFound(prod);
            }
            await _productService.Remove(prod);
            return Ok($"Product {prod.Name} Deleted");

        }
    }
}