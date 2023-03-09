using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.ShippingSlips.GetShippingSlip
{
    public class GetShippingSlipQuery : IRequest<ShippingSlipDto>
    {
        public GetShippingSlipQuery(Guid shippingSlipId) 
        {
            ShippingSlipId = shippingSlipId;
        }

        public Guid ShippingSlipId { get; set; }
    }
}
