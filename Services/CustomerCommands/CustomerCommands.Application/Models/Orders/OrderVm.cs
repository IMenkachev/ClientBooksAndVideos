namespace CustomerCommands.Application.Models.Orders
{
    public record OrderVm(
            Guid Id,
            decimal TotalPrice,
            string? DeliveryAddress,
            DateTime PurchaseDate,
            Guid CustomerId,
            ICollection<OrderItemVm> OrderItems);
}
