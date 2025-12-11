using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    /// <summary>
    /// Represents the base command for product-related operations.
    /// Inherits from <see cref="IRequest{Product}"/> to support MediatR request/response pattern.
    /// </summary>
    public abstract class ProductCommand : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the available stock for the product.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the image URL or path for the product.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the category identifier for the product.
        /// </summary>
        public int CategoryId { get; set; }
    }
}
