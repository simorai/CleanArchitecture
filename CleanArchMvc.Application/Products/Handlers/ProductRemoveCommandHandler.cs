using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    /// <summary>
    /// Handles the removal of a product using the <see cref="ProductRemoveCommand"/>.
    /// </summary>
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRemoveCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository to access product data.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="productRepository"/> is null.</exception>
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// Handles the request to remove a product by its unique identifier.
        /// </summary>
        /// <param name="request">The command containing the product identifier to remove.</param>
        /// <param name="cancellationToken">A cancellation token for the async operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the removed product if found; otherwise, an exception is thrown.
        /// </returns>
        /// <exception cref="ApplicationException">Thrown when the product entity could not be found.</exception>
        public async Task<Product> Handle(ProductRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _productRepository.RemoveAsync(product);
                return result;
            }
        }
    }
}
