using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoManager.DAL;
using ProyectoManager.Models;

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


    }
}
