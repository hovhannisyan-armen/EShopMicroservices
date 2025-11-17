using Eshop.Shared.CQRS;

namespace Catalog.Api.Products.Create;

public record CreateProductRequest(
    string Name,
    decimal Price,
    string ImagePath,
    string Description,
    List<string> Categories);

public record CreateProductResponse(Guid Id);

public record CreateProductResult(Guid Id);

public record CreateProductCommand(
    string Name,
    decimal Price,
    string ImagePath,
    string Description,
    List<string> Categories) : ICommand<CreateProductResult>;