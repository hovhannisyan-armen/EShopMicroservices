using Eshop.Shared.CQRS;

namespace Catalog.Api.Products.Delete;

public record DeleteProductResult(bool IsSuccess);

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

public record DeleteProductResponse(bool IsSuccess);
