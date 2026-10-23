using System;
using Proyecto_3;
using System.Collections.Generic;

namespace Proyecto_3
{

    public class RespuestaDTE
    {
        public resultadoAutorizaciones resultadoAutorizaciones {get; set;} = new resultadoAutorizaciones();
    }

    public class resultadoAutorizaciones
    {
        public int cantidadAutorizacionesAprobadas {get; set;}
        public int cantidadAutorizacionesRechazadasPorNitEmisorInexistente {get; set;}
        public int cantidadAutorizacionesRechazadasPorNitReceptorInexistente {get; set;}

        public detalleAprobaciones detalleAprobaciones {get; set;} = new detalleAprobaciones();
    }

    public class detalleAprobaciones
    {
        public List<CodReferencias>? dato {get; set; }
    }
}
