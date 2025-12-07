using Catalog.Api.Models;
using Eshop.Shared.CQRS;
using Marten;

namespace Catalog.Api.Products.Get;

public class GetProductsQueryHandler(IDocumentSession session) 
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductsResult(result);
    }
}