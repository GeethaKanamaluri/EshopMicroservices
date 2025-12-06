namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductsByIdEndpoint : ICarterModule
    {
        public record UpdateProductByIdRequest(Guid id,string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
   ICommand<UpdateProductByIdResult>;
        public record UpdateProductByIdResponse(bool isSuccess);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products",
                async(UpdateProductByIdRequest req,ISender sender) =>
                {
                    var command = req.Adapt<UpdateProductByIdCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<UpdateProductByIdResponse>();
                    return Results.Ok(response);
                }).WithName("Update Product")
            .Produces<UpdateProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
