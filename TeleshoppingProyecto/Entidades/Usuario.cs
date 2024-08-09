using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Usuario
    {

        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmarPassword { get; set; }

        [JsonIgnore]
        public List<Entrega>? entregas { get; set; }
    }
}
