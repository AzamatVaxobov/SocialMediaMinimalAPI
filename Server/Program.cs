using Configuration;
using DataAccess.DbContext;
using Endpoints;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register DB
builder.Services.AddSingleton(_ => new DatabaseInitializer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

// Register dependencies
builder.Services.AddApplicationServices();

// ?? Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My Minimal API",
        Version = "v1"
    });
});

var app = builder.Build();

// ?? Swagger middleware (always enabled for testing)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Minimal API v1");
});

// Modular endpoints
UserEndpoints.Register(app);
PostEndpoints.Register(app);
LikeEndpoints.Register(app);
FollowEndpoints.Register(app);

// Root test
app.MapGet("/", () => "API is running!");

app.Run();
