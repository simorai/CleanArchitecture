using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    /// <summary>
    /// Command to remove a product by its unique identifier.
    /// Implements <see cref="IRequest{Product}"/> to support MediatR request/response pattern.
    /// </summary>
    public class ProductRemoveCommand : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product to be removed.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRemoveCommand"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the product to remove.</param>
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
