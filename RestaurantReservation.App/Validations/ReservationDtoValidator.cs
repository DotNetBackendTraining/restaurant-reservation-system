using FluentValidation;
using RestaurantReservation.App.DTOs;

namespace RestaurantReservation.App.Validations;

public class ReservationDtoValidator : AbstractValidator<ReservationDto>
{
    public ReservationDtoValidator()
    {
        RuleFor(r => r.ReservationId)
            .Equal(0)
            .WithMessage("ReservationId must not be set for new reservations");

        RuleFor(r => r.ReservationDate)
            .NotEmpty()
            .Must(BeWithinCloseRange)
            .WithMessage("ReservationDate must be within the next year");

        RuleFor(r => r.PartySize)
            .GreaterThan(0)
            .WithMessage("PartySize must be greater than zero");

        RuleFor(r => r.CustomerId)
            .GreaterThan(0)
            .WithMessage("CustomerId must be greater than zero");

        RuleFor(r => r.TableId)
            .GreaterThan(0)
            .WithMessage("TableId must be greater than zero");
    }

    private static bool BeWithinCloseRange(DateTime reservationDate)
    {
        var today = DateTime.Today;
        return reservationDate >= today && reservationDate <= today.AddYears(1);
    }
}