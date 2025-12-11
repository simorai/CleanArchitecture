using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries
{
    /// <summary>
    /// Query to retrieve all products.
    /// Implements <see cref="IRequest{TResponse}"/> for MediatR request/response pattern.
    /// </summary>
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
