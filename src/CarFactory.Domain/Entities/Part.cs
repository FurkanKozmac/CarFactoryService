namespace CarFactory.Domain.Entities;

public class Part
{
    public int Id { get; private set; }
    public string PartNumber { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public int StockQuantity { get; private set; }

    public ICollection<VehicleModelPart> VehicleModelParts { get; private set; } = new List<VehicleModelPart>();
    
    private Part() {}

    public static Part Create(string partNumber, string name, int initialStock = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(partNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return new Part
        {
            PartNumber = partNumber.ToUpperInvariant(),
            Name = name,
            StockQuantity = initialStock
        };
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }
    }
    
    public void ConsumeStock(int quantity)
    {
        if (quantity <= 0) 
            throw new ArgumentOutOfRangeException(nameof(quantity));
        if (StockQuantity < quantity)
            throw new InvalidOperationException(
                $"Yetersiz stok: {Name}. Mevcut: {StockQuantity}, İstenen: {quantity}");
        StockQuantity -= quantity;
    }
}