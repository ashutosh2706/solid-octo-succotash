using MyApi.Data.Repository;
using MyApi.Data.Model;

namespace MyApi.Data.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<Product>> GetAllProds()
        {
            return await _productRepo.GetAll();
        } 

        public async Task<Product> GetProd(long id)
        {
            return await _productRepo.Get(id);
        }

        public async Task Add(Product product)
        {
            await _productRepo.Add(product);
        }

        public async Task Update(Product product)
        {
            await _productRepo.Update(product);
        }

        public async Task Remove(Product product)
        {
            await _productRepo.Remove(product);
        }
    }
}