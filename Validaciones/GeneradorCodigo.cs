using System;
using Proyecto_3;

namespace Proyecto_3
{
    public class GeneradorCodigo
    {
        public static string? ultimaFecha;
        public static int Correlativo;

        public long CodigoAutorizacion(string tiempoFactura)
        {
            Correlativo++;
        }
    }
}
