namespace OrdersSonae.Domain.Entities
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Stock = 100;
            Price = price;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Price  { get; set; }
        public int Stock { get; set; }

        public bool HasStock(int quantity)
        {
            return Stock >= quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (!HasStock(quantity))
                throw new InvalidOperationException("Insufficient stock");

            Stock -= quantity;
        }
    }
}
