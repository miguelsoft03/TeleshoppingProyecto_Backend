using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public int precioUnitario { get; set; }
        public int precioTotal { get; set; }
        public string estado { get; set; }

    }
}
