using Microsoft.EntityFrameworkCore;
using MyApi.Data.Model;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users {get; set;}
}