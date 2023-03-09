namespace CustomerCommands.Application.Models.Orders
{
    public record OrderItemVm(
            string Name,
            Guid OrderId,
            int? Quantity,
            Guid? MembershipId,
            Guid? ProductId);
}
