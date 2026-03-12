namespace CarFactory.Domain.Entities;

public class VehicleModel
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Year { get; private set; } = null!;

    public ICollection<VehicleModelPart> RequiredParts { get; private set; } 
        = new List<VehicleModelPart>();
    public ICollection<Vehicle> Vehicles { get; private set; } 
        = new List<Vehicle>();
    public ICollection<ProductionOrder> ProductionOrders { get; private set; } 
        = new List<ProductionOrder>();

    private VehicleModel() { }

    public static VehicleModel Create(string name, string year)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(year);

        return new VehicleModel
        {
            Name = name,
            Year = year
        };
    }
}