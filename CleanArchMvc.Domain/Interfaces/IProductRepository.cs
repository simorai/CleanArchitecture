using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int? categoryId);
    }
}
