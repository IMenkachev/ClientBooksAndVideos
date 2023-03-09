using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Products.GetProduct
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public GetProductQuery(Guid productId) 
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
