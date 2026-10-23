using System;
using Proyecto_3;
using System.Text.RegularExpressions;

namespace Proyecto_3
{
    public class GeneradorCodigo
    {
        public static string? ultimaFecha;
        public static int Correlativo;

        public long CodigoAutorizacion(string tiempoFactura)
        {
            Match match = Regex.Match(tiempoFactura, @"(\d{2})/(\d{2})/(\d{4})");

            if(!match.Success) return 0;

            string dia = match.Groups[1].Value;
            string mes = match.Groups[2].Value;
            string año = match.Groups[3].Value;

            string FechaCompleta = año + mes + dia;

            if(FechaCompleta == ultimaFecha)
            {
                 Correlativo++;
            } else
            {
                ultimaFecha = FechaCompleta;
                Correlativo = 1;
            }

            string correlativocompleto = Correlativo.ToString("D7");
            string CodigoAutorizado = FechaCompleta + correlativocompleto;

            return long.Parse(CodigoAutorizado);

        }
    }
}
