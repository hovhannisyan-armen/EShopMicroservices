using Catalog.Api.Exceptions;
using Catalog.Api.Models;
using Eshop.Shared.CQRS;
using Marten;

namespace Catalog.Api.Products.Update;

public class UpdateProductCommandHandler (IDocumentSession session)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product == null)
            throw new ProductNotFoundException();
        
        product.Name = request.Name;
        product.Price = request.Price;
        product.ImagePath = request.ImagePath;
        product.Categories = request.Categories;
        product.Description = request.Description;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);
        return new UpdateProductResult(true);
    }
}