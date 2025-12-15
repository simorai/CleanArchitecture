using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    /// <summary>
    /// Provides services for managing products, including CRUD operations and category queries.
    /// </summary>
    public class ProductService : IProductService
    {
        //private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        /// <param name="productRepository">The product repository for data access.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="productRepository"/> is null.</exception>
        public ProductService(IMapper mapper, /*IProductRepository productRepository*/ IMediator mediator)
        {
            //_productRepository = productRepository ??
            //     throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all products asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of <see cref="ProductDTO"/>.</returns>
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new Exception(nameof(productsQuery));
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);

        }

        ///// <summary>
        ///// Retrieves a product by its identifier asynchronously.
        ///// </summary>
        ///// <param name="id">The product identifier.</param>
        ///// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="ProductDTO"/> if found; otherwise, null.</returns>
        //public async Task<ProductDTO> GetById(int? id)
        //{
        //    var productEntity = await _productRepository.GetByIdAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        ///// <summary>
        ///// Retrieves a product along with its category by product identifier asynchronously.
        ///// </summary>
        ///// <param name="id">The product identifier.</param>
        ///// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="ProductDTO"/> with category information if found; otherwise, null.</returns>
        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productEntity = await _productRepository.GetProductCategoryAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        ///// <summary>
        ///// Adds a new product asynchronously.
        ///// </summary>
        ///// <param name="productDto">The product DTO to add.</param>
        ///// <returns>A task that represents the asynchronous operation.</returns>
        //public async Task Add(ProductDTO productDto)
        //{
        //    var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.CreateAsync(productEntity);
        //}

        ///// <summary>
        ///// Updates an existing product asynchronously.
        ///// </summary>
        ///// <param name="productDto">The product DTO with updated information.</param>
        ///// <returns>A task that represents the asynchronous operation.</returns>
        //public async Task Update(ProductDTO productDto)
        //{
        //    var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.UpdateAsync(productEntity);
        //}

        ///// <summary>
        ///// Removes a product by its identifier asynchronously.
        ///// </summary>
        ///// <param name="id">The product identifier.</param>
        ///// <returns>A task that represents the asynchronous operation.</returns>
        //public async Task Remove(int? id)
        //{
        //    var productEntity = _productRepository.GetByIdAsync(id).Result;
        //    await _productRepository.RemoveAsync(productEntity);
        //}
    }
}
