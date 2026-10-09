using System;

namespace Proyecto_3
{
    public class Contribuyente
    {
        public string NIT { get; set; }
        public string nombre { get; set; }

        public Contribuyente(string NIT, string nombre)
        {
            this.NIT = NIT;
            this.nombre = nombre;
        }

        public long DatoNIT()
        {
            return long.TryParse(this.NIT);
        }
    }
}
