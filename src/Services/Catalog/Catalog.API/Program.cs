
using Catalog.API.Data;

var builder = WebApplication.CreateBuilder(args);

//add services to the container

//here we didnt add carter assemble we dont have option to register assemble to this project So we remove carter from building blocks and register carter in this project 
builder.Services.AddCarter();

//register all services into project from mediator class library.
//Add mediator method ->register the mediator services and register service from assembly method tells mediator where to find our command and query handler classes
//MediatorR will handle bussiness logic through our command
builder.Services.AddMediatR(config =>
{    
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

var app = builder.Build();

//Configure the HTTP request pipeline
app.MapCarter();
app.UseExceptionHandler(options => { });
app.Run();
