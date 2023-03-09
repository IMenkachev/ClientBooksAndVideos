using FluentValidation;

namespace CustomerCommands.Application.Features.Commands.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().MaximumLength(20);

            RuleFor(c => c.LastName).NotEmpty().MaximumLength(30);
        }
    }
}
