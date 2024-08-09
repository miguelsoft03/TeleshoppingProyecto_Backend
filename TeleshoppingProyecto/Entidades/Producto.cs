using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsEditing { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsFavorite { get; set; }
    }
}
