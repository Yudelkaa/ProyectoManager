using Microsoft.EntityFrameworkCore;
using ProyectoManager.DAL;
using ProyectoManager.Models;
using System.Linq.Expressions;

namespace ProyectoManager.BLL
{
    public class PrioridadesBLL
    {
        private Contexto _contexto;

        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Save(Prioridades Prioridades)
        {
            if(Validar(Prioridades))
            {
                return false;
            }
            if (Prioridades.PrioridadesId == 0)
                _contexto.Prioridades.Add(Prioridades);
            else
                _contexto.Entry(Prioridades).State = EntityState.Modified;

            var saved = _contexto.SaveChanges() > 0;
            return saved;
        }

        public bool Validar(Prioridades prioridades)
        {
            bool encontrado = (_contexto.Prioridades.Any(p => p.Descripcion!.ToLower()
            == prioridades.Descripcion!.ToLower()));

            return encontrado;
        }


        public bool Modify(Prioridades prioridades)
        {
            _contexto.Update(prioridades);
            int cant = _contexto.SaveChanges();
            return cant > 0;
        }
        
        public bool Exist(int prioridadesId)
        {
            return _contexto.Prioridades.Any(o => o.PrioridadesId == prioridadesId);

        }

        private bool Insert(Prioridades prioridades)
        {
            _contexto.Prioridades.Add(prioridades);
            return _contexto.SaveChanges() > 0;
        }

        public bool Delete (int id)
        {
            var prioridad =_contexto.Prioridades.Find(id);
            _contexto.Prioridades.Remove(prioridad);

            var eliminado = _contexto.SaveChanges() > 0;
            return eliminado;
        }
        public async Task<Prioridades?> FindAsync(int id)
        {
            return await _contexto.Prioridades.FindAsync(id);
        }

        public Prioridades? Buscar(int prioridadesId)
        {
            return _contexto.Prioridades.Where(o => o.PrioridadesId
            == prioridadesId).AsNoTracking().SingleOrDefault();
        }

        public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> criterio)
        {
            return _contexto.Prioridades.AsNoTracking().Where(criterio).ToList();
        }

        public List<Prioridades> GetPrioridades()
        {
            var prioridades = _contexto.Prioridades.ToList();
            return prioridades;
        }
    }
}
