using Catalog.Api.Models;
using Eshop.Shared.CQRS;

namespace Catalog.Api.Products.GetByCategory;

public record GetByCategoryResult(IEnumerable<Product> Products);

public record GetByCategoryQuery(string Category) : IQuery<GetByCategoryResult>;

public record GetByCategoryResponse(IEnumerable<Product> Products);