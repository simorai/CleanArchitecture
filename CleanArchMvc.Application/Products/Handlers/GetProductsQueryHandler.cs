using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    /// <summary>
    /// Handles the retrieval of all products using the <see cref="GetProductsQuery"/>.
    /// </summary>
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsQueryHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository to access product data.</param>
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the request to retrieve all products.
        /// </summary>
        /// <param name="request">The query request for products.</param>
        /// <param name="cancellationToken">A cancellation token for the async operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of products.</returns>
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
