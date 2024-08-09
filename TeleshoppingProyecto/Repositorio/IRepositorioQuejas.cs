using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioQuejas
    {
        Task<IEnumerable<Queja>> ObtenerQuejas();
        Task<Queja> ObtenerQuejaPorId(int id);
        Task AgregarQueja(Queja queja);
        Task ActualizarQueja(Queja queja);
        Task EliminarQueja(int id);
    }
}
