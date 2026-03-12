using CarFactory.Domain.Enums;

namespace CarFactory.Domain.Entities;

public class ProductionOrder
{
    public int Id { get; private set; }
    public string OrderNumber { get; private set; } = null!;
    public int ModelId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }

    public VehicleModel Model { get; private set; } = null!;

    private ProductionOrder() { }

    public static ProductionOrder Create(string orderNumber, int modelId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(orderNumber);

        return new ProductionOrder
        {
            OrderNumber = orderNumber.ToUpperInvariant(),
            ModelId = modelId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending
        };
    }

    public void Start() => Status = OrderStatus.InProgress;
    public void Complete() => Status = OrderStatus.Completed;
    public void Cancel() => Status = OrderStatus.Cancelled;
}