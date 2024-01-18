using Microsoft.EntityFrameworkCore;
using ProyectoManager.DAL;
using ProyectoManager.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace ProyectoManager.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;

        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Guardar(Prioridades prioridad)
        {
            if (!await Existe(prioridad.PrioridadesId))
                return await Insertar(prioridad);
            else
                return await Modificar(prioridad);
        }

        private async Task<bool> Insertar(Prioridades prioridades)
        {
            _contexto.Prioridades.Add(prioridades);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridades prioridades)
        {
            _contexto.Update(prioridades);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public Task<bool> Validar(Prioridades prioridades)
        {
             var encontrado =  (_contexto.Prioridades.Any(p => p.Descripcion!.ToLower()
            == prioridades.Descripcion!.ToLower()));

            return Task.FromResult(encontrado);
        }

        public async Task<bool> Eliminar(Prioridades prioridades)
        {
            var cantidad = await _contexto.Prioridades
                .Where(p => p.PrioridadesId == prioridades.PrioridadesId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Prioridades?> Buscar(int prioridadesId)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadesId == prioridadesId);
        }


        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return await _contexto.Prioridades.AsNoTracking().Where(criterio).ToListAsync();
        }

        public async Task<bool> Existe(int prioridadesId)
        {
            return await _contexto.Prioridades
                .AnyAsync(p => p.PrioridadesId == prioridadesId);

        }

        public List<Prioridades> GetPrioridades()
        {
            var prioridades = _contexto.Prioridades.ToList();
            return prioridades;
        }

        public async Task<Prioridades?> FindAsync(int id)
        {
            return await _contexto.Prioridades.FindAsync(id);
        }
    }
}
