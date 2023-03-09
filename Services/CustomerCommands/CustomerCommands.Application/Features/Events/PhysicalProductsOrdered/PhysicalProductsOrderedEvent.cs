using MediatR;

namespace CustomerCommands.Application.Features.Events.PhysicalProductsOrdered
{
    public record PhysicalProductsOrderedEvent(Guid OrderId) : INotification;
}
