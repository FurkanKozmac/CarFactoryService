using MediatR;

namespace CarFactory.Application.Commands.MoveVehicle;

public record MoveVehicleCommand(string VIN, string OperatorId) : IRequest<MoveVehicleResponse>
{
    
}