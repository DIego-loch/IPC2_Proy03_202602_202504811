using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Proyecto_3;

namespace Proyecto_3
{
    public class Cargar
    {

        public List<Contribuyente>? CargarJSON()
        {
            if (!File.Exists("Datos/InfoRTU.json")) return new List<Contribuyente>();

            string JSON = File.ReadAllText("Datos/InfoRTU.json");
            return JsonSerializer.Deserialize<List<Contribuyente>>(JSON);
        }
    }
}
