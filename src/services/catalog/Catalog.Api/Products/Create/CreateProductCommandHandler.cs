using Catalog.Api.Models;
using Eshop.Shared.CQRS;
using Marten;

namespace Catalog.Api.Products.Create;

public class CreateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            ImagePath = request.ImagePath,
            Categories = request.Categories,
            Description = request.Description,
        };
        
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(Guid.Empty);
    }
}