using MediatR;
using OrdersSonae.Business.DTOs;
using OrdersSonae.Domain.Entities;

namespace OrdersSonae.Business.Queries
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private static readonly List<Order> _orders = new();

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = _orders.FirstOrDefault(o => o.Id == request.OrderId);
            if (order == null)
                throw new Exception("Order not found");

            return new OrderDto
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalAmount = order.TotalAmount,
                CreatedAt = order.CreatedAt
            };
        }
    }
}
