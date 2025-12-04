using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProcductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
   ICommand<CreateProductResult>;
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProcductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProcductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/products/{response.Id}", response);
            })
            .WithName("Create Product")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Description");          
        }
    }
}
