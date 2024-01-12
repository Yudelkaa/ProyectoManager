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
            if (Prioridades.PrioridadesId == 0)
                _contexto.Prioridades.Add(Prioridades);
            else
                _contexto.Entry(Prioridades).State = EntityState.Modified;

            var saved = _contexto.SaveChanges() > 0;
            return saved;
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

        public bool Eliminar(Prioridades prioridades)
        {
            _contexto.Entry(prioridades).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
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


    }
}
