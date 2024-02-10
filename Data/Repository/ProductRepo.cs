using Microsoft.EntityFrameworkCore;
using MyApi.Data.Model;

namespace MyApi.Data.Repository
{
    public class ProductRepo : IProductRepo
    {   
        private readonly AppContext _context;
        public ProductRepo(AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}