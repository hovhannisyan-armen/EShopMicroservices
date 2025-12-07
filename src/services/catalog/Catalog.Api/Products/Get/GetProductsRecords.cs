using Catalog.Api.Models;
using Eshop.Shared.CQRS;

namespace Catalog.Api.Products.Get;

public record GetProductsQuery() : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

public record GetProductsResponse(IEnumerable<Product> Products);