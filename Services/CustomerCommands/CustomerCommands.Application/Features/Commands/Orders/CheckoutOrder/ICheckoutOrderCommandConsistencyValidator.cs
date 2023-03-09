namespace CustomerCommands.Application.Features.Commands.Orders.CheckoutOrder
{
    public interface ICheckoutOrderCommandConsistencyValidator
    {
        Task ValidateAsync(CheckoutOrderCommand request);
    }
}
