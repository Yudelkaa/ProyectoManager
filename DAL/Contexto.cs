using Microsoft.EntityFrameworkCore;
using ProyectoManager.Models;

namespace ProyectoManager.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Prioridades> Prioridades { get; set; }
        public Contexto(DbContextOptions<Contexto> Options): base(Options) { }

        
    }
}
