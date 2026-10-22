using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Proyecto_3;

namespace Proyecto_3
{
    [ApiController]
    [Route("api/[controller]")]

    public class AutorizacionController : ControllerBase
    {
        private readonly ArbolRTU ArbolFacturas;

        public AutorizacionController(ArbolRTU arbol)
        {
            ArbolFacturas = arbol;
        }

        [HttpPost]
        public IActionResult ProcesarFactura([FromBody] List<DTE> dTEs)
        {

            return Ok()
        }

    }

}
