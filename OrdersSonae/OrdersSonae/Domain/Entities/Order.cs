using OrdersSonae.Domain.Enums;

namespace OrdersSonae.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = new Guid();
        public Product Product { get; set; }
        public DateTime Created_At { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
    }
}