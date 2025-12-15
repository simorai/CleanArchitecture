using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    /// <summary>
    /// Handles the retrieval of a product by its unique identifier using the <see cref="GetProductByIdQuery"/>.
    /// </summary>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository to access product data.</param>
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the request to retrieve a product by its unique identifier.
        /// </summary>
        /// <param name="request">The query request containing the product identifier.</param>
        /// <param name="cancellationToken">A cancellation token for the async operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the product if found; otherwise, <c>null</c>.
        /// </returns>
        public async Task<Product> Handle(GetProductByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
