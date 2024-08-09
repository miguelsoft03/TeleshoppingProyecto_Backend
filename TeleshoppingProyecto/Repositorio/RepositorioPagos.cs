using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioPagos: IRepositorioPagos
    {
        private readonly ApplicationDbContext context;
        public RepositorioPagos(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Pago>> ObtenerTodos()
        {
            return await context.Pagos.ToListAsync();
        }

        public async Task<int> CrearPago(Pago pago)
        {
            context.Pagos.Add(pago);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ActualizarPago(Pago pago)
        {
            context.Entry(pago).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return pago.id;
        }

        public async Task EliminarPago(string identificacion)
        {
            var pago = await context.Pagos.FirstOrDefaultAsync(r => r.identificacion == identificacion);
            if (pago != null)
            {
                context.Pagos.Remove(pago);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Pago no encontrado");
            }
        }

        public async Task<List<string>> ObtenerProductosPorCliente(string cliente)
        {
            var ordenes = await context.Ordenes
                .Where(o => o.cliente == cliente)
                .Select(o => o.producto)
                .ToListAsync();

            return ordenes;
        }

        public async Task<Pago> ObtenerPagoPorIdentificacion(string identificacion)
        {
            return await context.Pagos.FirstOrDefaultAsync(p => p.identificacion == identificacion);
        }


        public async Task<bool> ActualizarPagoPorIdentificacion(string identificacion, Pago pago)
        {
            var pagoExistente = await context.Pagos
                .Where(u => u.identificacion == identificacion)
                .FirstOrDefaultAsync();

            if (pagoExistente == null)
            {
                return false; // Usuario no encontrado
            }

            pagoExistente.identificacion = pago.identificacion;
            pagoExistente.cliente = pago.cliente;
            pagoExistente.direccion = pago.direccion;
            pagoExistente.telefono = pago.telefono;
            pagoExistente.tipo = pago.tipo;
            pagoExistente.detalles = pago.detalles;
            pagoExistente.estado = pago.estado;

            context.Pagos.Update(pagoExistente);
            await context.SaveChangesAsync();

            return true; 
        }


    }
}
