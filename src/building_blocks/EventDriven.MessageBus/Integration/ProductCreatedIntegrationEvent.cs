namespace EventDriven.MessageBus;

public class ProductCreatedIntegrationEvent : Event
{
    public ProductCreatedIntegrationEvent(
        Guid id,
        string title,
        string description,
        double price,
        int quantity)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Quantity = quantity;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}