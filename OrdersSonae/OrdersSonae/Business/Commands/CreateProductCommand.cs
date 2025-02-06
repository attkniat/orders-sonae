using MediatR;

namespace OrdersSonae.Business.Commands
{
    public record CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; init; }
        public decimal Price { get; init; }

        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}