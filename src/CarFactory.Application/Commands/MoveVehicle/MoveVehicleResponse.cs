namespace CarFactory.Application.Commands.MoveVehicle;

public record MoveVehicleResponse(
    string VIN,
    string NewStationName,
    string NewStatus,
    DateTime MovedAt,
    string ModelName,
    string Color
);