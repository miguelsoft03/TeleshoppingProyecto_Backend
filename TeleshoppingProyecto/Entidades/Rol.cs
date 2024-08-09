using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Rol
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string confirmarPassword { get; set; }
    }
}
