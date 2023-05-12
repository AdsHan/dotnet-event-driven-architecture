using EventDriven.API.Data.Entities;
using EventDriven.Core.Data.DomainObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventDriven.API.Data;

public class CatalogDbContext : DbContext
{
    private readonly IMediator _mediator;

    public CatalogDbContext(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var events = ChangeTracker
            .Entries<BaseEntity>()
            .SelectMany(e => e.Entity.GetEvents())
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var @event in events)
        {
            await _mediator.Publish(@event, cancellationToken);
        }

        return result;
    }
}

