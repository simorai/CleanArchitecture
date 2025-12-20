using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
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
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new Exception(nameof(productsQuery));
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);

        }


        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
            {
                throw new Exception($"Entity could not be loaded");
            }
            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }


        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
            {
                throw new Exception($"Entity could not be loaded");
            }
            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);

        }


        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
            {
                throw new Exception($"Entity could not be loaded");
            }
            await _mediator.Send(productRemoveCommand);
        }
    }
}
