using System;
using System.Text.Json;
using System.IO;
using Proyecto_3;

namespace Proyecto_3
{

    public class Guardar
    {
        private readonly ArbolRTU Serealizacion;
        public Guardar(ArbolRTU serealizacion)
        {
            Serealizacion = serealizacion;
        }

        public List<Contribuyente>? ObtenerRecorrido()
        {
            return Serealizacion.RecorrerRTU();
        }

        public void GuardarEnJSON()
        {
            string JSON = JsonSerializer.Serialize(ObtenerRecorrido());
            File.WriteAllText("Datos/InfoRTU.json", JSON);
        }

    }
}
