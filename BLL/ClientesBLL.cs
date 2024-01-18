using Microsoft.EntityFrameworkCore;
using ProyectoManager.DAL;
using ProyectoManager.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace ProyectoManager.BLL
{
    public class ClientesBLL
    {
        private readonly Contexto _contextoClientes;

        public ClientesBLL(Contexto contextoClientes)
        {
            _contextoClientes = contextoClientes;
        }
        public async Task<bool> Guardar(Clientes clientes)
        {
            if (!await Existe(clientes.ClientesId))
                return await Insertar(clientes);
            else
                return await Modificar(clientes);
        }

        private async Task<bool> Insertar(Clientes clientes)
        {
            _contextoClientes.Clientes.Add(clientes);
            return await _contextoClientes.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes clientes)
        {
            _contextoClientes.Update(clientes);
            return await _contextoClientes.SaveChangesAsync() > 0;
        }

		public  bool Validar(Clientes clientes)
		{
			var encontrado = (_contextoClientes.Clientes.Any(p => p.Nombres!.ToLower()
		   == clientes.Nombres!.ToLower()));

			return encontrado;
		}

		public async Task<bool> Eliminar(Clientes clientes)
        {
            var cantidad = await _contextoClientes.Clientes
                .Where(p => p.ClientesId == clientes.ClientesId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Clientes?> Buscar(int clientesId)
        {
            return await _contextoClientes.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ClientesId == clientesId);
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            return await _contextoClientes.Clientes.AsNoTracking().Where(criterio).ToListAsync();
        }

        public async Task<bool> Existe(int clientesId)
        {
            return await _contextoClientes.Clientes
                .AnyAsync(p => p.ClientesId == clientesId);

        }

        public List<Clientes> GetPrioridades()
        {
            var clientes = _contextoClientes.Clientes.ToList();
            return clientes;
        }

		public async Task<Clientes?> FindAsync(int id)
		{
			return await _contextoClientes.Clientes.FindAsync(id);
		}
	}
}
