using System;
using Proyecto_3;
using System.Text.Json.Serialization;
namespace Proyecto_3
{
    public class DTE
    {
        [JsonPropertyName("TIEMPO")]
        public string Tiempo { get; set; }

        [JsonPropertyName("REFERENCIA")]
        public string Referencia { get; set; }

        [JsonPropertyName("NIT EMISOR")]
        public string NitEmisor { get; set; }

        [JsonPropertyName("NIT RECEPTOR")]
        public string NitReceptor { get; set; }

        [JsonPropertyName("VALOR")]
        public double Valor { get; set; }

        [JsonPropertyName("IVA")]
        public double IVA { get; set; }

        [JsonPropertyName("TOTAL")]
        public double Total { get; set; }
    }
}
