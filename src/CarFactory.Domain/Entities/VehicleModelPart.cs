namespace CarFactory.Domain.Entities;

public class VehicleModelPart
{
    public int VehicleModelId { get; private set; }
    public int PartId { get; private set; }
    public int RequiredQuantity { get; private set; }

    public VehicleModel VehicleModel { get; private set; } = null!;
    public Part Part { get; private set; } = null!;

    private VehicleModelPart() { }

    public static VehicleModelPart Create(int vehicleModelId, int partId, int requiredQuantity)
    {
        if (requiredQuantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(requiredQuantity));

        return new VehicleModelPart
        {
            VehicleModelId = vehicleModelId,
            PartId = partId,
            RequiredQuantity = requiredQuantity
        };
    }
}