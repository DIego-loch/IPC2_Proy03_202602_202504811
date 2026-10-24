using System;
using Proyecto_3;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_3
{
    [ApiController]
    [Route("api/[controller]")]

    public class RTUController : ControllerBase
    {
        private readonly ArbolRTU Arbol;
        private readonly Guardar guardado;

        public RTUController(ArbolRTU arbol, Guardar guardados)
        {
            Arbol = arbol;
            guardado = guardados;
        }

        // Metodo de procesar en donde se ingresa el JSON
        [HttpPost("Procesar")]
        public IActionResult Procesar([FromBody] List<Contribuyente> ListaContribuyentes)
        {
            int contadorActualizados = 0, contadorNuevos = 0, contadorRechazados = 0;
            foreach (Contribuyente list in ListaContribuyentes)
            {
                ValidadorNIT validador = new ValidadorNIT(list.NIT);

                if (validador.Validacion())
                {
                    if (Arbol.ActualizarContribuyente(list.NIT, list.nombre))
                    {
                        contadorActualizados++;
                    }
                    else
                    {
                        Arbol.NuevoContribuyente(list);
                        contadorNuevos++;
                    }
                }
                else
                {
                    contadorRechazados++;
                }
            }
            guardado.GuardarEnJSON();
            Respuesta r = new Respuesta
            {
                CONTRIBUYENTES_ACTUALIZADOS = contadorActualizados,
                CONTRIBUYENTES_NUEVOS = contadorNuevos,
                NITS_INVALIDOS = contadorRechazados
            };
            return Ok(r);
        }

    }
}
