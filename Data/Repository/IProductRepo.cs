using MyApi.Data.Model;

namespace MyApi.Data.Repository
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(long id);
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(Product product);

    }
}