using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Products.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public GetProductsQuery() { }
    }
}
