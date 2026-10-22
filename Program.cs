using Proyecto_3;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ArbolRTU>();
builder.Services.AddSingleton<ListaDTE>();
builder.Services.AddSingleton<ListaCodReferencias>();
builder.Services.AddSingleton<Guardar>();
builder.Services.AddSingleton<Cargar>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
