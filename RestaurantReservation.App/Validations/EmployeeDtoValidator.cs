using FluentValidation;
using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Validations;

public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeDtoValidator()
    {
        RuleFor(e => e.RestaurantId).GreaterThan(0);
        RuleFor(e => e.FirstName)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(e => e.LastName)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(e => e.Position)
            .NotEmpty()
            .MaximumLength(50);
    }
}