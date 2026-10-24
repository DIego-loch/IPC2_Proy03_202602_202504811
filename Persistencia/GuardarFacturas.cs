using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Proyecto_3;

namespace Proyecto_3
{
    public class GuardarFacturas
    {

        private readonly ListaDTE ArchivoSerealizar;

        public GuardarFacturas(ListaDTE ArchivosPersistentes)
        {
            ArchivoSerealizar = ArchivosPersistentes;
        }

        public void SerealizarLista()
        {
            string ArchivoPersistente = JsonSerializer.Serialize(ArchivoSerealizar.DTEs);
            Directory.CreateDirectory("Datos");
            File.WriteAllText("Datos/InfoDTE.json", ArchivoPersistente);
        }
    }
}
