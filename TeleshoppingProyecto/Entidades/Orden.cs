using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Orden
    {
        public int Id { get; set; }
        public string codigo { get; set; }
        public string cliente { get; set; }
        public string fecha { get; set; }
        public string producto { get; set; }
        public string total { get; set; }
        public string estado { get; set; }
    }
}
