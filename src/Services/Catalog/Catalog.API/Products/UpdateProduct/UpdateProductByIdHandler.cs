namespace Catalog.API.Products.UpdateProduct
{
   
    public record UpdateProductByIdCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductByIdResult>;
    public record UpdateProductByIdResult(bool isSuccess);
    public class UpdateProductByIdHandler(IDocumentSession session, ILogger<UpdateProductByIdHandler> logger) 
        : ICommandHandler<UpdateProductByIdCommand, UpdateProductByIdResult>
    {
        public async Task<UpdateProductByIdResult> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductByIdHandler.Handled called with {@query}", command);
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null)
            {
                throw new productNotFoundException();
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            await session.SaveChangesAsync();

            return new UpdateProductByIdResult(true);
        }
    }
}
