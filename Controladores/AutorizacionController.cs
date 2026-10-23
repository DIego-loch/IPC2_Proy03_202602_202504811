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

    }

}
