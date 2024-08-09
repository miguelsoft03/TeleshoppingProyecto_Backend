using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class Entrega
    {
        public int Id { get; set; }
        public int usuarioId { get; set; }
        public Usuario? usuario { get; set; }
        public string ordenCompra { get; set; }
        public int estado { get; set; }
        public string descripcion { get; set; }
        public string nombreEmpresaTransporte { get; set; }
        public DateTime fechaEnvio { get; set; }
        public int numSeguimiento { get; set; }
        public int tipoTransporteId { get; set; }
        public TipoTransporte? tipoTransporte { get; set; }
        public DateTime fechaEntrega { get; set; }
        public string direccionEntrega { get; set; }


    }
}
