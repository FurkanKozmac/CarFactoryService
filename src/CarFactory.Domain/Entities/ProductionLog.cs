namespace CarFactory.Domain.Entities;

public class ProductionLog
{
    public int Id { get; private set; }
    public string VehicleVIN { get; private set; } = null!;
    public int StationId { get; private set; }
    public DateTime EntryDate { get; private set; }
    public DateTime? ExitDate { get; private set; }
    public string OperatorId { get; private set; } = null!;

    public Vehicle Vehicle { get; private set; } = null!;
    public Station Station { get; private set; } = null!;

    private ProductionLog() { }

    public static ProductionLog CreateEntry(string vehicleVIN, int stationId, string operatorId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleVIN);
        ArgumentException.ThrowIfNullOrWhiteSpace(operatorId);

        return new ProductionLog
        {
            VehicleVIN = vehicleVIN,
            StationId = stationId,
            OperatorId = operatorId,
            EntryDate = DateTime.UtcNow
        };
    }

    public void RecordExit(DateTime exitDate)
    {
        if (ExitDate.HasValue)
        {
            throw new InvalidOperationException("Bu log zaten kapatılmış.");
        }

        ExitDate = DateTime.UtcNow;
    }
        
}