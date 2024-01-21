using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;


namespace ProyectoManager.Models
{
    public class Clientes
    {
        [Key]
        public int ClientesId { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        public string? Nombres { get; set; }


        [Required(ErrorMessage = "Por favor, ingrese su número de contacto")]
        public long Celular { get; set; }


        [RegularExpression(@"^\d{3}-\d{7}-\d$", ErrorMessage = "Por favor, ingrese su RNC")]
        public string? RNC { get; set; }


        [Required(ErrorMessage = "Por favor, complete el campo")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Por favor, ingrese su dirección")]
        public string? Direccion { get; set; }
    } 
}