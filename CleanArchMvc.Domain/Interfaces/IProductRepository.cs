using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    /// <summary>
    /// Defines a repository interface for <see cref="Product"/> entities, including domain-specific queries.
    /// </summary>
    public interface IProductRepository/* : IGenericRepository<Product>*/
    {
        ///// <summary>
        ///// Asynchronously retrieves all products.
        ///// </summary>
        ///// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of products.</returns>
        //Task<IEnumerable<Product>> GetProductsAsync();

        ///// <summary>
        ///// Asynchronously retrieves products by their category.
        ///// </summary>
        ///// <param name="categoryId">The unique identifier of the category. If null, retrieves products without filtering by category.</param>
        ///// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of products in the specified category.</returns>
        //Task<IEnumerable<Product>> GetProductsByCategoryAsync(int? categoryId);

        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
