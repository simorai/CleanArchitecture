using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    /// <summary>
    /// Handles the creation of a new product using the <see cref="ProductCreateCommand"/>.
    /// </summary>
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCreateCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository to access product data.</param>
        public ProductCreateCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Handles the request to create a new product.
        /// </summary>
        /// <param name="request">The command containing the product data to create.</param>
        /// <param name="cancellationToken">A cancellation token for the async operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the created product.
        /// </returns>
        /// <exception cref="ApplicationException">Thrown when there is an error creating the product entity.</exception>
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price,
                              request.Stock, request.Image);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
