using System;
using Proyecto_3;

namespace Proyecto_3
{
    public class DTE
    {
        public string Tiempo { get; set; }
        public string Referencia { get; set; }
        public string NitEmisor { get; set; }
        public string NitReceptor { get; set; }
        public double Valor { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }

        public DTE(string tiempo, string referencia, string nit1, string nit2, double valor, double iva, double total)
        {
            Tiempo = tiempo;
            Referencia = referencia;
            NitEmisor = nit1;
            NitReceptor = nit2;
            Valor = valor;
            IVA = iva;
            Total = total;
        }
    }
}
