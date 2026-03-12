using CarFactory.Domain.Enums;

namespace CarFactory.Domain.Entities;

public class Station
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public int SequenceOrder { get; private set; }
    public StationType Type { get; private set; }

    public ICollection<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
    public ICollection<ProductionLog> ProductionLogs { get; private set; } = new List<ProductionLog>();

    private Station() { }

    public static Station Create(string name, int sequenceOrder, StationType type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (sequenceOrder <= 0)
            throw new ArgumentOutOfRangeException(nameof(sequenceOrder));

        return new Station
        {
            Name = name,
            SequenceOrder = sequenceOrder,
            Type = type
        };
    }
}
