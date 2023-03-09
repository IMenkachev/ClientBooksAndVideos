using FluentValidation;

namespace CustomerCommands.Application.Features.Commands.Orders.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty();

            RuleFor(p => p.OrderItems).NotEmpty();
        }
    }
}
