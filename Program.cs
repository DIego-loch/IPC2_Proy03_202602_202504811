using Proyecto_3;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ArbolRTU>();
builder.Services.AddSingleton<ListaDTE>();
builder.Services.AddSingleton<ListaCodReferencias>();
builder.Services.AddSingleton<Guardar>();
builder.Services.AddSingleton<Cargar>();
builder.Services.AddSingleton<GuardarFacturas>();
builder.Services.AddSingleton<CargarFacturas>();

var app = builder.Build();

// AQUÍ ESTÁ EL BLOQUE CORRECTO (Cargar el RTU al arrancar)
using (var scope = app.Services.CreateScope())
{
    var arbol = scope.ServiceProvider.GetRequiredService<ArbolRTU>();
    var cargador = scope.ServiceProvider.GetRequiredService<Cargar>();
    var CargarFactura = scope.ServiceProvider.GetRequiredService<CargarFacturas>();
    var ListaInicializarFacturas = scope.ServiceProvider.GetRequiredService<ListaDTE>();

    var ListaIngresoDTE = CargarFactura.Deserealizar();
    var contribuyentesGuardados = cargador.CargarJSON();
    foreach (var c in contribuyentesGuardados)
    {
        arbol.NuevoContribuyente(c);
    }

    foreach (var d in ListaIngresoDTE)
    {
        ListaInicializarFacturas.DTEs.Add(d);
    }
}

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
