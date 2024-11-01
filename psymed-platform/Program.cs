using YourProjectName.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura la API
builder.ConfigureApi();

var app = builder.Build();

// Configura los endpoints
app.ConfigureEndpoints();

app.Run();