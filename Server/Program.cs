using Configuration;
using DataAccess.DbContext;
using Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Register DatabaseInitializer
builder.Services.AddSingleton(_ => new DatabaseInitializer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

// Register all dependencies using centralized DI configuration
builder.Services.AddApplicationServices();

var app = builder.Build();

// Register endpoints modularly
UserEndpoints.Register(app);
PostEndpoints.Register(app);
LikeEndpoints.Register(app);
FollowEndpoints.Register(app);

app.MapGet("/", () => "API is running!");

app.Run();