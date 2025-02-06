using MediatR;
using OrdersSonae.Business.DTOs;

namespace OrdersSonae.Business.Queries
{
    public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;
}