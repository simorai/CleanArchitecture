using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    /// <summary>
    /// Defines a generic repository interface for basic CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T">The type of entity, which must inherit from <see cref="Entity"/>.</typeparam>
    public interface IGenericRepository<T> where T : Entity
    {
        /// <summary>
        /// Asynchronously retrieves all entities of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity if found; otherwise, null.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Asynchronously updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Asynchronously deletes an entity from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}
