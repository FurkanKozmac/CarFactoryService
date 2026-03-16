using FluentValidation;

namespace CarFactory.Application.Commands.MoveVehicle;

public class MoveVehicleCommandValidator: AbstractValidator<MoveVehicleCommand>
{
    public MoveVehicleCommandValidator()
    {
        RuleFor(x => x.VIN)
            .NotEmpty().WithMessage("VIN boş olamaz.")
            .Length(17).WithMessage("VIN 17 karakter olmalıdır.")
            .Matches("^[A-HJ-NPR-Z0-9]+$").WithMessage("VIN sadece harf ve rakam içermelidir.");

        RuleFor(x => x.OperatorId)
            .NotEmpty().WithMessage("OperatorId boş olamaz.");
    }
}