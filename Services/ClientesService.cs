using Microsoft.EntityFrameworkCore;
using ProyectoManager.DAL;
using ProyectoManager.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace ProyectoManager.Services
{
    public class ClientesService
    {
        private readonly Contexto _contextoClientes;

        public ClientesService(Contexto contextoCliente)
        {
            _contextoClientes = contextoCliente;
        }
        public async Task<bool> Guardar(Clientes cliente)
        {
            if (!Validar(cliente))
            {
                if (!await Existe(cliente.ClientesId))
                    return await Insertar(cliente);
                else
                    return await Modificar(cliente);
            }
            return false;
        }

        private async Task<bool> Insertar(Clientes cliente)
        {
            _contextoClientes.Clientes.Add(cliente);
            return await _contextoClientes.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            _contextoClientes.Update(cliente);
            return await _contextoClientes.SaveChangesAsync() > 0;
        }

		public bool Validar(Clientes cliente)
		{
			var encontrado = (_contextoClientes.Clientes.Any(p => p.Nombres!.ToLower()
		   == cliente.Nombres!.ToLower()));

			return encontrado;
		}

		public async Task<bool> Eliminar(Clientes cliente)
        {
            var cantidad = await _contextoClientes.Clientes
                .Where(p => p.ClientesId == cliente.ClientesId)
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

        public List<Clientes> GetClientes()
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
