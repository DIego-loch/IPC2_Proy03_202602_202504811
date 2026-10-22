using System;
using Proyecto_3;

namespace Proyecto_3
{
    public class IngresoFacturasAprobadas
    {
        private readonly ListaDTE listaDTE;
        public DTE dTEs1 { get; set; }

        public IngresoFacturasAprobadas(ListaDTE listaSimple, DTE dTEs)
        {
            listaDTE = listaSimple;
            dTEs1 = dTEs;
        }
        // Metodo de ingreso
        public void MetodoIngreso()
        {
                listaDTE.DTEs.Add(dTEs1);
        }
    }
}
