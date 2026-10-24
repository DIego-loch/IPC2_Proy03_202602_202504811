using System;
using Microsoft.AspNetCore.Mvc;
using Proyecto_3;

namespace Proyecto_3
{
    [ApiController]
    [Route("api/[controller]")]

    public class AutorizacionController : ControllerBase
    {
        private readonly ArbolRTU ArbolFacturas;
        private readonly ListaDTE listaDTE;
        private readonly ListaCodReferencias listaCodReferencias;
        private readonly GuardarFacturas Facturas;

        public AutorizacionController(ArbolRTU arbol, ListaDTE lista1, ListaCodReferencias lista2, GuardarFacturas factura)
        {
            ArbolFacturas = arbol;
            listaDTE = lista1;
            listaCodReferencias = lista2;
            Facturas = factura;
        }

        [HttpPost]
        public IActionResult ProcesarFactura([FromBody] List<DTE> dTEs)
        {
            RespuestaAutorizacion respuesta = new RespuestaAutorizacion(dTEs, ArbolFacturas, listaDTE, listaCodReferencias);
            respuesta.ContadoresGenerales();

            RespuestaDTE respuesta_general = new RespuestaDTE();
            respuesta_general.resultadoAutorizaciones.cantidadAutorizacionesAprobadas = respuesta.FacAprobados;
            respuesta_general.resultadoAutorizaciones.cantidadAutorizacionesRechazadasPorNitEmisorInexistente = respuesta.FactRechazadosEmisorInexistente;
            respuesta_general.resultadoAutorizaciones.cantidadAutorizacionesRechazadasPorNitReceptorInexistente = respuesta.FactRechazadosReceptorInexistente;
            respuesta_general.resultadoAutorizaciones.detalleAprobaciones.dato = listaCodReferencias.dato;
            Facturas.SerealizarLista();

            return Ok(respuesta_general);
        }


        [HttpGet("ConsultarContribuyente")]
        public IActionResult ConsultarContribuyente(
            [FromQuery] string nit,
            [FromQuery] string tipo,
            [FromQuery] string fechaInicio,
            [FromQuery] string fechaFin)
        {
            List<DTE> resultados = new List<DTE>();

            foreach (DTE dte in listaDTE.DTEs)
            {
                bool coincideNit = false;

                if (tipo.ToLower() == "emitidas" && dte.NitEmisor == nit)
                    coincideNit = true;
                else if (tipo.ToLower() == "recibidas" && dte.NitReceptor == nit)
                    coincideNit = true;

                if (coincideNit)
                {
                    string[] partes = dte.Tiempo.Split(' ');
                    string fechaFactura = partes[1];

                    bool fechaValida = true;

                    if (!string.IsNullOrEmpty(fechaInicio) && !string.IsNullOrEmpty(fechaFin))
                    {
                        DateTime fFactura = DateTime.ParseExact(fechaFactura, "dd/MM/yyyy", null);
                        DateTime fInicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", null);
                        DateTime fFin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", null);

                        fechaValida = (fFactura >= fInicio && fFactura <= fFin);
                    }

                    if (fechaValida)
                    {
                        resultados.Add(dte);
                    }
                }
            }

            return Ok(resultados);
        }

        [HttpGet("ResumenIva")]
        public IActionResult ResumenIva([FromQuery] string fecha)
        {
            var resumen = new List<object>();

            foreach (DTE dte in listaDTE.DTEs)
            {
                if (dte.Tiempo.Contains(fecha))
                {
                    resumen.Add(new
                    {
                        NIT_Emisor = dte.NitEmisor,
                        NIT_Receptor = dte.NitReceptor,
                        IVA = dte.IVA
                    });
                }
            }
            return Ok(resumen);
        }

        [HttpGet("ResumenRango")]
        public IActionResult ResumenRango([FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            decimal total = 0;
            int cantidad = 0;

            foreach (DTE dte in listaDTE.DTEs)
            {
                string[] partes = dte.Tiempo.Split(' ');
                string fechaFactura = partes[1];

                if (!string.IsNullOrEmpty(fechaInicio) && !string.IsNullOrEmpty(fechaFin))
                {
                    DateTime fFactura = DateTime.ParseExact(fechaFactura, "dd/MM/yyyy", null);
                    DateTime fInicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", null);
                    DateTime fFin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", null);

                    if (fFactura >= fInicio && fFactura <= fFin)
                    {
                        total += (decimal)dte.Total;
                        cantidad++;
                    }
                }
            }

            var resultado = new { CantidadFacturas = cantidad, TotalFacturado = total };
            return Ok(resultado);
        }

        [HttpPost("Inicializar")]
        public IActionResult Inicializar()
        {
            if (System.IO.File.Exists("Datos/InfoRTU.json")) System.IO.File.Delete("Datos/InfoRTU.json");
            if (System.IO.File.Exists("Datos/InfoDTE.json")) System.IO.File.Delete("Datos/InfoDTE.json");

            listaDTE.DTEs.Clear();
            listaCodReferencias.dato.Clear();

            return Ok(new { mensaje = "Sistema reiniciado correctamente." });
        }

        [HttpGet("DatosGrafica")]
        public IActionResult DatosGrafica()
        {
            var totalesPorFecha = new Dictionary<string, decimal>();

            foreach (var dte in listaDTE.DTEs)
            {
                string[] partes = dte.Tiempo.Split(' ');
                string fecha = partes[1];

                if (totalesPorFecha.ContainsKey(fecha))
                    totalesPorFecha[fecha] += (decimal)dte.Total;
                else
                    totalesPorFecha[fecha] = (decimal)dte.Total;
            }
            return Ok(totalesPorFecha);
        }

    }

}
