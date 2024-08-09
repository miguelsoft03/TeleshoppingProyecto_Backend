using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string origen { get; set; }
        public string contacto { get; set; }

        [JsonIgnore]
        public List<Stock>? Stock { get; set; }

    }
}
