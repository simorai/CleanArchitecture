using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository : IGenericInterface<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

    }
}
