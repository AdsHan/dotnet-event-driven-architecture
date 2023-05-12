using EventDriven.Core.Data.DomainObjects;
using EventDriven.MessageBus;

namespace EventDriven.API.Data.Entities;

public class ProductModel : BaseEntity
{

    // EF Construtor
    public ProductModel()
    {

    }

    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public static ProductModel Create(
        string title,
        string description,
        double price,
        int quantity)
    {
        var product = new ProductModel
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Price = price,
            Quantity = quantity
        };

        product.AddEvent(new ProductCreatedDomainEvent(Guid.NewGuid(), product.Id));

        return product;
    }
}
