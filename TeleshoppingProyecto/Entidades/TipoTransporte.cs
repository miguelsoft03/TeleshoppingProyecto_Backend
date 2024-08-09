using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class TipoTransporte
    {
        public int Id { get; set; }
        public int empresaTransporteId { get; set; }
        public EmpresaTransporte? empresaTransporte { get; set; }
        public string tipoTransporte { get; set; } 
        public int estado {  get; set; }


        [JsonIgnore]
        public List<Entrega>? entregas { get; set; } // Relación con Entrega


    }
}

