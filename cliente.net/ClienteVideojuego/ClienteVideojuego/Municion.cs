using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClienteVideojuego
{
    internal class Municion
    {
        [JsonPropertyName("nombre")]
        public string nombreMunicion { get; set; }

        [JsonPropertyName("cadencia")]
        public int cadencia { get; set; } // 👈 tipo correcto

        [JsonPropertyName("dañoArea")]
        public bool dañoArea { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }
        public override string ToString()
        {
            return $"Municion: Nombre={nombreMunicion}, Cadencia={cadencia}, Daño de Área={dañoArea}, Índice={id}";
        }
    }
}
