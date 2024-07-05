using FluentValidation;
using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Validations;

public class CustomerDtoValidator : AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(c => c.CustomerId)
            .Equal(0)
            .WithMessage("CustomerId must not be set");
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(c => c.LastName)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);
        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\d{3}-\d{3}-\d{4}$")
            .WithMessage("Phone number must be in the format xxx-xxx-xxxx, e.g., 123-456-7890")
            .MaximumLength(12);
    }
}