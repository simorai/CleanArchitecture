using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

    }
}
