using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioEmpresasTransporte
    {
        Task<List<EmpresaTransporte>> ObtenerTodos();
        Task<EmpresaTransporte> ObtenerPorId(int id);
        Task<int> Crear(EmpresaTransporte empresaTransporte);
        Task<int> ModificarEmpresaTransporte(EmpresaTransporte empresaTransporte);
        Task EliminarEmpresaTransporte(int id);
        Task <EmpresaTransporte> ObtenerPorIdRelacion(int id);
    }
}
