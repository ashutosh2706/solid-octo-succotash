using MyApi.Data.Model;

namespace MyApi.Data.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProds();
        Task<Product> GetProd(long id);
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(Product product);
    }
}