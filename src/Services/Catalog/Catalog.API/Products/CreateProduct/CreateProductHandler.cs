namespace Catalog.API.Products.CreateProduct
{
    public record CreateProcductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) :
     ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    
    public class CreateProductCommandValidator : AbstractValidator<CreateProcductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Requried");
        }
    }
    public class CreateProductCommandHandler(IDocumentSession session
                                             //,IValidator<CreateProcductCommand> validator
                                             ) 
                                             : ICommandHandler<CreateProcductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProcductCommand command, CancellationToken cancelToken)
        {
            //var result = await validator.ValidateAsync(command, cancelToken);
            //var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            //if (errors.Any()) { }

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
            session.Store(product);
            await session.SaveChangesAsync(cancelToken);
            //return result

            return new CreateProductResult(product.Id);
        }
    }
}
