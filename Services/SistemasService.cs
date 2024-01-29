using Microsoft.EntityFrameworkCore;
using ProyectoManager.DAL;
using ProyectoManager.Models;

namespace ProyectoManager.Services
{
    public class SistemasService
    {
        private readonly Contexto _contexto;

        public SistemasService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Sistemas>> ObtenerTodos()
        {
            return await _contexto.Sistemas.ToListAsync();
        }

        public async Task<Sistemas> ObtenerPorId(int id)
        {
            return await _contexto.Sistemas.FindAsync(id);
        }

        public async Task<bool> Guardar(Sistemas sistema)
        {
            if (sistema.ID == 0)
            {
                _contexto.Sistemas.Add(sistema);
            }
            else
            {
                _contexto.Sistemas.Update(sistema);
            }

            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var sistema = await _contexto.Sistemas.FindAsync(id);

            if (sistema == null)
            {
                return false;
            }

            _contexto.Sistemas.Remove(sistema);
            return await _contexto.SaveChangesAsync() > 0;
        }
    }
}
