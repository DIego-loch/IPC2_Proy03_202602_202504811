using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Proyecto_3;

namespace Proyecto_3
{
    public class CargarFacturas
    {
        public List<DTE>? Deserealizar()
        {
            if(!File.Exists("Datos/InfoDTE.json")) return new List<DTE>();
            string date = File.ReadAllText("Datos/InfoDTE.json");

            return JsonSerializer.Deserialize<List<DTE>>(date);
        }
    }
}
