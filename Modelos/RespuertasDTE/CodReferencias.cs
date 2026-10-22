using System;
using Proyecto_3;

namespace Proyecto_3
{
    public class CodReferencias
    {
        public string referencia { get; set; }
        public long codigoAprobacion { get; set; }

        public CodReferencias(string refer, long cod)
        {
            referencia = refer;
            codigoAprobacion = cod;
        }
    }
}
