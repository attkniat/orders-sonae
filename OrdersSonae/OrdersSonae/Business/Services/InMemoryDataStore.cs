using OrdersSonae.Domain.Entities;

namespace OrdersSonae.Business.Services
{
    public class InMemoryDataStore
    {
        public List<Product> Products { get; } = new();
        public List<Order> Orders { get; } = new();
    }
}