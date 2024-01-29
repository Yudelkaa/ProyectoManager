using Microsoft.EntityFrameworkCore;
using ProyectoManager.DAL;
using ProyectoManager.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace ProyectoManager.Services
{
    public class PrioridadesService
    {
        private readonly Contexto _contexto;

        public PrioridadesService(Contexto contexto)
        {
            _contexto = contexto;
        }

		public async Task<bool> Guardar(Prioridades prioridad)
		{
			if (prioridad.PrioridadesId == 0)
				return await Insertar(prioridad);
			else
				return await Modificar(prioridad);
		}

		private async Task<bool> Insertar(Prioridades prioridad)
        {
            _contexto.Prioridades.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }


		public async Task<bool> Modificar(Prioridades prioridad)
		{
			// Asegúrate de que PrioridadesId sea una clave primaria válida y no 0 si ya existe en la base de datos
			if (prioridad.PrioridadesId != 0)
			{
				_contexto.Update(prioridad);
				var modifico = await _contexto.SaveChangesAsync() > 0;
				return modifico;
			}
			else
			{
				// Maneja el escenario de error donde PrioridadesId es 0
				return false;
			}
		}


		public Task<bool> Validar(Prioridades prioridad)
        {
            var encontrado = (_contexto.Prioridades.Any(p => p.Descripcion!.ToLower()
           == prioridad.Descripcion!.ToLower()));

            return Task.FromResult(encontrado);
        }

        public async Task<bool> Eliminar(Prioridades prioridad)
        {
            var cantidad = await _contexto.Prioridades
                .Where(p => p.PrioridadesId == prioridad.PrioridadesId)
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
            var prioridad = _contexto.Prioridades.ToList();
            return prioridad;
        }
        public async Task<Prioridades?> FindAsync(int id)
        {
            return await _contexto.Prioridades.FindAsync(id);
        }
    }
}
