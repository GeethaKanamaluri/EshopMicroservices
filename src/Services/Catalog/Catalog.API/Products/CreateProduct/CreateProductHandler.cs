using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProcductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
     ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProcductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProcductCommand command, CancellationToken c)
        {
            //bussiness logic to create product          
            
            var product = new Product
            { 
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price                
            };
            //save database
            //return result

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
