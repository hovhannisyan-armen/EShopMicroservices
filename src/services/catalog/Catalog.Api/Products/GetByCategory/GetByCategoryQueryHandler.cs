using Catalog.Api.Models;
using Eshop.Shared.CQRS;
using Marten;
using Marten.Linq.QueryHandlers;

namespace Catalog.Api.Products.GetByCategory;

public class GetByCategoryQueryHandler(IDocumentSession session)
    : IQueryHandler<GetByCategoryQuery, GetByCategoryResult>
{
    public async Task<GetByCategoryResult> Handle(GetByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(x => x.Categories.Contains(request.Category))
            .ToListAsync(cancellationToken);

        return new GetByCategoryResult(products);
    }
}