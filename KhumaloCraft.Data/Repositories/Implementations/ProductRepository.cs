using Microsoft.EntityFrameworkCore;
using KhumaloCraft.Data.Data;
using KhumaloCraft.Data.Entities;
using KhumaloCraft.Data.Repositories.Interfaces;

namespace KhumaloCraft.Data.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
  private readonly ApplicationDbContext _dbContext;

  public ProductRepository(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<List<Product>> GetAllProductsAsync()
  {
    return await _dbContext.Products.Include(p => p.Category).ToListAsync();
  }

  public async Task<Product?> GetProductByIdAsync(int productId)
  {
    return await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == productId);
  }

  public async Task AddProductAsync(Product product)
  {
    await _dbContext.Products.AddAsync(product);  // Add product to the database
  }

  public async Task UpdateProductAsync(Product product)
  {
    _dbContext.Products.Update(product);  // Mark the product as updated
  }

  public async Task DeleteProductAsync(Product product)
  {
    _dbContext.Products.Remove(product);  // Remove the product from the database
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();  // Commit changes to the database
  }
}
