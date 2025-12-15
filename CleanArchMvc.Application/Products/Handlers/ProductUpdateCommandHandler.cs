using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    /// <summary>
    /// Handles the update of an existing product using the <see cref="ProductUpdateCommand"/>.
    /// </summary>
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductUpdateCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository to access product data.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="productRepository"/> is null.</exception>
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// Handles the request to update an existing product.
        /// </summary>
        /// <param name="request">The command containing the updated product data.</param>
        /// <param name="cancellationToken">A cancellation token for the async operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the updated product.
        /// </returns>
        /// <exception cref="ApplicationException">Thrown when the product entity could not be found.</exception>
        public async Task<Product> Handle(ProductUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price,
                                request.Stock, request.Image, request.CategoryId);

                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}
