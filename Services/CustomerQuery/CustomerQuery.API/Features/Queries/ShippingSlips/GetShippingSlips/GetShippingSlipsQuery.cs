using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.ShippingSlips.GetShippingSlips
{
    public class GetShippingSlipsQuery : IRequest<List<ShippingSlipDto>>
    {
        public GetShippingSlipsQuery() { }
    }
}
