using Catalog.Api.Models;
using Eshop.Shared.CQRS;
using Marten;

namespace Catalog.Api.Products.Delete;

public class DeleteProductCommandHandler (IDocumentSession session)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult(true);
    }
}