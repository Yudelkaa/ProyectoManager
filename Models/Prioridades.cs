using System.ComponentModel.DataAnnotations;
namespace ProyectoManager.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadesId { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public int DiasCompromiso { get; set; }


    }
}
