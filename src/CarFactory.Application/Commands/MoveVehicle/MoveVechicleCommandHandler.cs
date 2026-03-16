using CarFactory.Application.Interfaces;
using CarFactory.Domain.Entities;
using MediatR;

namespace CarFactory.Application.Commands.MoveVehicle;

public class MoveVechicleCommandHandler : IRequestHandler<MoveVehicleCommand, MoveVehicleResponse>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IStationRepository _stationRepository;
    private readonly IProductionLogRepository _productionLogRepository;

    public MoveVechicleCommandHandler(IVehicleRepository vehicleRepository, IStationRepository stationRepository, IProductionLogRepository productionLogRepository)
    {
        _vehicleRepository = vehicleRepository;
        _stationRepository = stationRepository;
        _productionLogRepository = productionLogRepository;
    }

    public async Task<MoveVehicleResponse> Handle(MoveVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByVinAsync(request.VIN, cancellationToken);
        if (vehicle == null)
            throw new Exception($"Araç bulunamadı: {request.VIN}");
        
        var nextStation = await _stationRepository.GetNextStationAsync(
            vehicle.CurrentStation?.SequenceOrder ?? 0, cancellationToken);
        if (nextStation == null)
            throw new Exception("Sonraki istasyon bulunamadı.");
        
        vehicle.MoveToStation(nextStation.Id);
        
        var log = ProductionLog.CreateEntry(vehicle.VIN, nextStation.Id, request.OperatorId);
        await _productionLogRepository.AddAsync(log, cancellationToken);
        
        await _vehicleRepository.UpdateAsync(vehicle, cancellationToken);
        await _vehicleRepository.SaveChangesAsync(cancellationToken);
        
        return new MoveVehicleResponse(
            vehicle.VIN,
            nextStation.Name,
            vehicle.CurrentStatus.ToString(),
            DateTime.UtcNow,
            vehicle.Model.Name,
            vehicle.Color
        );
    }
}