namespace Catalog.API.Products.UpdateProduct
{
   
    public record UpdateProductByIdCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
        : ICommand<UpdateProductByIdResult>;
    public record UpdateProductByIdResult(bool isSuccess);
    public class UpdateProductByIdHandler(IDocumentSession session) 
        : ICommandHandler<UpdateProductByIdCommand, UpdateProductByIdResult>
    {
        public async Task<UpdateProductByIdResult> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
        {            
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null)
            {
                throw new productNotFoundException(command.Id);
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
