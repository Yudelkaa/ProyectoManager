using Microsoft.EntityFrameworkCore;
using ProyectoManager.Models;

namespace ProyectoManager.DAL
{
	public class ContextoClientes: DbContext
	{
		public DbSet<Clientes> Clientes { get; set; }
		public ContextoClientes(DbContextOptions<ContextoClientes> Options) : base(Options) { }
	}
}
