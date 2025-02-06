using MediatR;
using OrdersSonae.Business.DTOs;
using OrdersSonae.Business.Services;

namespace OrdersSonae.Business.Queries
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly InMemoryDataStore _dataStore;

        public GetOrderQueryHandler(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = _dataStore.Orders.FirstOrDefault(o => o.Id == request.OrderId);

            if (order == null)
                throw new Exception("Order not found");

            return new OrderDto
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalAmount = order.TotalAmount,
                CreatedAt = order.CreatedAt,
                Status = order.Status.ToString(),
            };
        }
    }
}