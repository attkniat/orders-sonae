using MediatR;

namespace OrdersSonae.Business.Commands
{
    public record CreateOrderCommand : IRequest<Guid>
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }

        public CreateOrderCommand(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
