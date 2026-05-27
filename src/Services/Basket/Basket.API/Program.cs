var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
var validate = typeof(ValidationBehaviours<,>);
var logging = typeof(LoggingBehaviour<,>);

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
