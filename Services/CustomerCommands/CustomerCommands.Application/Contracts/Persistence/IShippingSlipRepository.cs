using CustomerCommands.Domain.ShippingSlips;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IShippingSlipRepository : IAsyncRepository<ShippingSlip>
    {
    }
}
