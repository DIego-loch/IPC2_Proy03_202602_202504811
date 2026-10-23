using System;
using Proyecto_3;

namespace Proyecto_3
{
    public class RespuestaAutorizacion
    {
        public List<DTE> ListaFacturas { get; set; }
        public int FacAprobados { get; set; }
        public int FactRechazadosEmisorInexistente { get; set; }
        public int FactRechazadosReceptorInexistente { get; set; }
        private readonly ArbolRTU arbol;
        private readonly ListaDTE listaDTE;
        private readonly ListaCodReferencias listaCodReferencias;

        public RespuestaAutorizacion(List<DTE> Lista, ArbolRTU arbolito, ListaDTE lista, ListaCodReferencias lis)
        {
            ListaFacturas = Lista;
            arbol = arbolito;
            listaDTE = lista;
            listaCodReferencias = lis;
        }

        public void ContadoresGenerales()
        {
            //Emisor y Receptor
            foreach (DTE dTEs in ListaFacturas)
            {
                Contribuyente? Emisor = arbol.MostrarContribuyente(dTEs.NitEmisor);
                Contribuyente? Receptor = arbol.MostrarContribuyente(dTEs.NitReceptor);

                if (Emisor == null)
                    FactRechazadosEmisorInexistente++;

                if (Receptor == null)
                    FactRechazadosReceptorInexistente++;

                if (Emisor != null && Receptor != null)
                {
                    //Creamos el codigo de autorizacio
                    GeneradorCodigo cod = new GeneradorCodigo();
                    long CodigoAutorizado = cod.CodigoAutorizacion(dTEs.Tiempo);

                    // Guardamos la referencia de la factura
                    // y el codigo que le corresponde por su autorizacion
                    CodReferencias dato = new CodReferencias(dTEs.Referencia, CodigoAutorizado);
                    listaCodReferencias.dato.Add(dato);

                    IngresoFacturasAprobadas IngresoFacturas = new IngresoFacturasAprobadas(listaDTE, dTEs);
                    IngresoFacturas.MetodoIngreso();
                    FacAprobados++;
                }


            }

        }
    }
}
