using Microsoft.EntityFrameworkCore;
using ProyectoManager.DAL;
using ProyectoManager.Models;
using System.Linq.Expressions;

namespace ProyectoManager.Services
{
	public class TicketsService
	{
		private readonly Contexto _contextoTickets;
		public TicketsService(Contexto contextoCliente)
		{
			_contextoTickets = contextoCliente;
		}

		public async Task<bool> Guardar(Tickets ticket)
		{
			if (!Validar(ticket))
			{
				if (!await Existe(ticket.TicketId))
					return await Insertar(ticket);
				else
					return await Modificar(ticket);
			}
			return false;
		}

		private async Task<bool> Insertar(Tickets ticket)
		{
			_contextoTickets.Tickets.Add(ticket);
			return await _contextoTickets.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Tickets ticket)
		{
			_contextoTickets.Update(ticket);
			return await _contextoTickets.SaveChangesAsync() > 0;
		}

		public bool Validar(Tickets ticket)
		{
			var encontrado = _contextoTickets.Tickets.Any(p => p.Descripcion!.ToLower()
		   == ticket.Descripcion!.ToLower());

			return encontrado;
		}

		public async Task<bool> Eliminar(Tickets ticket)
		{
			var cantidad = await _contextoTickets.Clientes
				.Where(p => p.ClientesId == ticket.TicketId)
				.ExecuteDeleteAsync();

			return cantidad > 0;
		}

		public async Task<Tickets?> Buscar(int clientesId)
		{
			return await _contextoTickets.Tickets
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.TicketId == clientesId);
		}

		public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
		{
			return await _contextoTickets.Tickets.AsNoTracking().Where(criterio).ToListAsync();
		}

		public async Task<bool> Existe(int ticketId)
		{
			return await _contextoTickets.Tickets
				.AnyAsync(p => p.TicketId == ticketId);

		}

		public List<Tickets> GetTickets()
		{
			var tickets = _contextoTickets.Tickets.ToList();
			return tickets;
		}

		public async Task<Tickets?> FindAsync(int id)
		{
			return await _contextoTickets.Tickets.FindAsync(id);
		}
	}
}

