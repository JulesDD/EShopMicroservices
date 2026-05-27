var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
var validate = typeof(ValidationBehaviours<,>);
var logging = typeof(LoggingBehaviour<,>);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(validate);
    config.AddOpenBehavior(logging);
});

var app = builder.Build();

app.MapCarter();
app.Run();
