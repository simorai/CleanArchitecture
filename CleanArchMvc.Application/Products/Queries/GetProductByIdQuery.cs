using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries
{
    /// <summary>
    /// Query to retrieve a product by its unique identifier.
    /// Implements <see cref="IRequest{Product}"/> for MediatR request/response pattern.
    /// </summary>
    public class GetProductByIdQuery : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product to retrieve.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductByIdQuery"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
