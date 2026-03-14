using CarFactory.Domain.Enums;

namespace CarFactory.Domain.Entities;

public class Vehicle
{
    public string VIN { get; private set; } = null!;
    public int ModelId { get; private set; }
    public string Color { get; private set; } = null!;
    public VehicleStatus CurrentStatus { get; private set; }
    public int? CurrentStationId { get; private set; }
    public DateTime ProductionStartDate { get; private set; }
    public VehicleModel Model { get; private set; } = null!;
    public Station? CurrentStation { get; private set; }
    public ICollection<ProductionLog> ProductionLogs { get; private set; } 
        = new List<ProductionLog>();
    
    private Vehicle() {}

    public static Vehicle Create(string vin, int modelId, string color)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vin);
        ArgumentException.ThrowIfNullOrWhiteSpace(color);

        return new Vehicle
        {
            VIN = vin.ToUpperInvariant(),
            ModelId = modelId,
            Color = color,
            CurrentStatus = VehicleStatus.Pending,
            ProductionStartDate = DateTime.UtcNow
        };
    }

    public void MoveToStation(int stationId)
    {
        if (CurrentStatus == VehicleStatus.Completed)
        {
            throw new InvalidOperationException("Tamamlanmış araç taşınamaz.");
        }

        CurrentStationId = stationId;
        CurrentStatus = VehicleStatus.InProduction;
    }

    public void Complete()
    {
        CurrentStatus = VehicleStatus.Completed;
        CurrentStationId = null;
    }

    public void MarkAsDefective()
    {
        CurrentStatus = VehicleStatus.Defective;
    }
}