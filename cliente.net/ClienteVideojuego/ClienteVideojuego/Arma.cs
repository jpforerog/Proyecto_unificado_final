using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NodaTime;

namespace ClienteVideojuego
{
    internal class Arma
    {
        [JsonPropertyName("nombre")]
        public string nombre { get; set; }

        [JsonPropertyName("daño")]
        public int daño { get; set; } // 👈 tipo correcto

        [JsonPropertyName("vida")]
        public int vida { get; set; }

        [JsonPropertyName("velocidad")]
        public double velocidad { get; set; }

        [JsonPropertyName("municion")]
        public int municion { get; set; }

        [JsonPropertyName("fechaCreacion")]
        public DateTime FechaCreacionDate { get; set; }  // ✅ Esto sí puede deserializarlo // 👈 tipo correcto

        [JsonPropertyName("tipoMunicion")]
        public Municion tipoMunicion { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }


        /*[JsonIgnore]
        public DateTime FechaCreacionDate =>
             new DateTime(
            fechaCreacion[0],
            fechaCreacion[1],
            fechaCreacion[2],
            fechaCreacion[3],
            fechaCreacion[4],
            fechaCreacion[5]
        );*/






    }
}
