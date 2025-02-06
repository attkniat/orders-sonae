using MediatR;
using OrdersSonae.Business.DTOs;

namespace OrdersSonae.Business.Queries
{
    public record GetOrderQuery : IRequest<OrderDto>
    {
        public Guid OrderId { get; init; }

        public GetOrderQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
