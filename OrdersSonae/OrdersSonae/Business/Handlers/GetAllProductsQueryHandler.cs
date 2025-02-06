using MediatR;
using OrdersSonae.Business.DTOs;
using OrdersSonae.Business.Queries;
using OrdersSonae.Business.Services;

namespace OrdersSonae.Business.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly InMemoryDataStore _dataStore;

        public GetAllProductsQueryHandler(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _dataStore.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                Price = p.Price
            });
        }
    }
}