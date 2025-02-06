namespace OrdersSonae.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Order(Guid productId, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            TotalAmount = quantity * unitPrice;
            CreatedAt = DateTime.UtcNow;
        }
    }
}