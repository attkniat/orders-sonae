using MediatR;
using OrdersSonae.Business.DTOs;
using OrdersSonae.Business.Services;

namespace OrdersSonae.Business.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = ProductStore.Products.FirstOrDefault(p => p.Id == request.ProductId);
            if (product == null)
                throw new Exception("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price
            };
        }
    }
}