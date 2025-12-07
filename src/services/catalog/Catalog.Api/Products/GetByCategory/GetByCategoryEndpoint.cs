using Carter;
using Mapster;
using MediatR;

namespace Catalog.Api.Products.GetByCategory;

public class GetByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetByCategoryQuery(category));
            var response = result.Adapt<GetByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductByCategory")
        .Produces<GetByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get product By category")
        .WithDescription("Get product by category");
    }
}