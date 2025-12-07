using Catalog.Api.Models;
using Catalog.Api.Products.Get;
using Eshop.Shared.CQRS;

namespace Catalog.Api.Products.GetSingle;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

public record GetProductByIdResponse(Product Product);  
