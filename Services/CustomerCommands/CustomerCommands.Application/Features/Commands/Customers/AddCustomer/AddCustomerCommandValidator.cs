using FluentValidation;

namespace CustomerCommands.Application.Features.Commands.Customers.AddCustomer
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
            RuleFor(c => c.Customer.FirstName).NotEmpty().MaximumLength(20);

            RuleFor(c => c.Customer.LastName).NotEmpty().MaximumLength(30);
        }
    }
}
