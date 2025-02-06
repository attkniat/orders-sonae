using MediatR;
using OrdersSonae.Business.Commands;
using OrdersSonae.Business.Services;
using OrdersSonae.Domain.Entities;

namespace OrdersSonae.Business.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price);
            ProductStore.Products.Add(product);
            return product.Id;
        }
    }
}