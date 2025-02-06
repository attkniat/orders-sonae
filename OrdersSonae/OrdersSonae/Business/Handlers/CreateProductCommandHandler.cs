using MediatR;
using OrdersSonae.Business.Commands;
using OrdersSonae.Business.Services;
using OrdersSonae.Domain.Entities;

namespace OrdersSonae.Business.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly InMemoryDataStore _dataStore;
        public CreateProductCommandHandler(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }


        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price);
            _dataStore.Products.Add(product);
            return product.Id;
        }
    }
}