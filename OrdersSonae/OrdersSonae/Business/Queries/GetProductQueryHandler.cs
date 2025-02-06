using MediatR;
using OrdersSonae.Business.DTOs;
using OrdersSonae.Business.Services;

namespace OrdersSonae.Business.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly InMemoryDataStore _dataStore;

        public GetProductQueryHandler(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _dataStore.Products.FirstOrDefault(p => p.Id == request.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return productDto;
        }
    }
}