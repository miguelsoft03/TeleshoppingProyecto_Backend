using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Queja
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string DetallesIncidente { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;  // Para administrador
        public string Estado { get; set; }   // En Proceso, Resuelta, Cancelada, etc.
    }
}
