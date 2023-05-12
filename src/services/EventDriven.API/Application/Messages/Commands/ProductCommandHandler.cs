using EventDriven.API.Data;
using EventDriven.API.Data.Entities;
using EventDriven.Core.Communication;
using MediatR;

namespace EventDriven.API.Application.Messages.Commands;

public class ProductCommandHandler : CommandHandler,
    IRequestHandler<CreateProductCommand, BaseResult>
{
    private readonly CatalogDbContext _dbContext;

    public ProductCommandHandler(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BaseResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = ProductModel.Create(
            command.Title,
            command.Description,
            command.Price,
            command.Quantity);

        _dbContext.Add(product);

        await _dbContext.SaveChangesAsync();

        BaseResult.Response = product.Id;

        return BaseResult;
    }
}
