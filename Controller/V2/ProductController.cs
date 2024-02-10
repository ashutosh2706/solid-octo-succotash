using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data.Service;
using MyApi.Data.Model;

namespace MyApi.Controller.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("/api/v{version:apiVersion}/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private const int PAGE_SIZE = 5;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1)
        {
            var prods = await _productService.GetAllProds();
            var totalPage = (int)Math.Ceiling((decimal)prods.Count() / PAGE_SIZE);

            var products = prods
                .Skip((page - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProd([FromForm] string name, [FromForm] string description)
        {
            var product = new Product { Name = name, Info = description };
            await _productService.Add(product);
            return Created("api/product", new
            {
                code = 201,
                message = "Product added successfully"
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
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