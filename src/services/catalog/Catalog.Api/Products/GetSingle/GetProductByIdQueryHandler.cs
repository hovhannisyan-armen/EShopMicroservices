using Catalog.Api.Exceptions;
using Catalog.Api.Models;
using Eshop.Shared.CQRS;
using Marten;

namespace Catalog.Api.Products.GetSingle;

public class GetProductByIdQueryHandler (IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product == null)
            throw new ProductNotFoundException();
        
        return new GetProductByIdResult(product);
    }
}