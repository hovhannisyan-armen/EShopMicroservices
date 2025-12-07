using Eshop.Shared.CQRS;

namespace Catalog.Api.Products.Update;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    string ImagePath,
    string Description,
    List<string> Categories) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);
    
public record UpdateProductRequest(
    Guid Id,
    string Name,
    decimal Price,
    string ImagePath,
    string Description,
    List<string> Categories);
    
public record UpdateProductResponse(bool IsSuccess);
