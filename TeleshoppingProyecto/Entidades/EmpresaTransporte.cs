using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeleshoppingProyecto.Entidades
{
    public class EmpresaTransporte
    {
        public int Id {  get; set; }
        public string nombreEmpresa { get; set; }
        public string ruc {  get; set; }
        public string correo {  get; set; }
        public DateTime fechaRegistro { get; set; }
        public string telefono { get; set; }
        public int estado {  get; set; }

        [JsonIgnore]
        public List<TipoTransporte>? tipoTransportes { get; set; }


    }
}
