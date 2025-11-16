using Catalog.Api.Models;
using Eshop.Shared.CQRS;

namespace Catalog.Api.Products.Create;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            ImagePath = request.ImagePath,
            Categories = request.Categories,
            Description = request.Description,
        };

        return Task.FromResult(new CreateProductResult(Guid.Empty));
    }
}