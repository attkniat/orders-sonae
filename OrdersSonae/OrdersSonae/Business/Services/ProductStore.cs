using OrdersSonae.Domain.Entities;

namespace OrdersSonae.Business.Services
{
    public class ProductStore
    {
        public static List<Product> Products { get; } = new List<Product>();
    }
}