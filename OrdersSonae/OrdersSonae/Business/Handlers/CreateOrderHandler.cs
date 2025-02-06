using MediatR;
using OrdersSonae.Business.Commands;
using OrdersSonae.Domain.Entities;

namespace OrdersSonae.Business.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Order> _orders = new();

        public CreateOrderCommandHandler()
        {
            if (!_products.Any())
            {
                _products.Add(new Product("Sample Product", 29.99m));
            }
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var product = _products.FirstOrDefault(p => p.Id == request.ProductId);
            if (product == null)
                throw new Exception("Product not found");

            if (!product.HasStock(request.Quantity))
                throw new InvalidOperationException("Insufficient stock");

            product.DecreaseStock(request.Quantity);
            var order = new Order(request.ProductId, request.Quantity, product.Price);
            _orders.Add(order);

            return order.Id;
        }
    }
}
