using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoManager.Models
{
	public class Tickets
	{
		[Key]
		public int TicketId { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public int ClienteId { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Debe ser válido")]
		public int SistemaId { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Debe ser válido")]
		public int PrioridadId { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public string? SolicitadoPor { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public string? Asunto { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public string? Descripcion { get; set; }
	}
}
