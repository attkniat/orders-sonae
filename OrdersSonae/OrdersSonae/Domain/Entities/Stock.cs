namespace OrdersSonae.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; } = new Guid();
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}