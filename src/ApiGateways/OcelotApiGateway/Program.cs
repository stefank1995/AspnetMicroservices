using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


//.net7 
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();

//.net6
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddOcelot();


var app = builder.Build();

await app.UseOcelot();


app.MapGet("/", () => "Hello World!");

app.Run();
