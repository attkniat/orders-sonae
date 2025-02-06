using MediatR;
using OrdersSonae.Business.DTOs;

namespace OrdersSonae.Business.Queries
{
    public record GetProductQuery : IRequest<ProductDto>
    {
        public Guid ProductId { get; init; }

        public GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}