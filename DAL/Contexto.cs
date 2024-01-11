using Microsoft.EntityFrameworkCore;
using ProyectoManager.Models;

namespace ProyectoManager.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options): base(Options) { }

        public DbSet<Prioridades> Prioridades { get; set; }
    }
}
