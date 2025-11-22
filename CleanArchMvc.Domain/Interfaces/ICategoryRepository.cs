using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    /// <summary>
    /// Defines a repository interface for <see cref="Category"/> entities, including domain-specific queries.
    /// </summary>
    public interface ICategoryRepository /*: IGenericRepository<Category>*/
    {
        /// <summary>
        /// Asynchronously retrieves all categories.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable of categories.
        /// </returns>
        //Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<IEnumerable<Category>> GetCatories();
        Task<Category> GetById(int? id);

        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
    }
}
