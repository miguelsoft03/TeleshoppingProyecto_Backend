using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Stock
    {
        public int Id { get; set; }
        public int stockcant { get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public string precio { get; set; }
        public int proveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }









    }
}
