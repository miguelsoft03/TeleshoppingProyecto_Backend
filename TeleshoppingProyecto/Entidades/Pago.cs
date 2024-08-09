using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Pago
    {
        public int id { get; set; }
        public string identificacion { get; set; }
        public string cliente { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string tipo { get; set; }
        public string detalles { get; set; }
        public string estado { get; set; }
        public string numTarjeta{ get; set; }
        public string expiracion { get; set; }
        public string codigoSeguridad { get; set; }



    }
}
