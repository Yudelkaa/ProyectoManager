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


        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingrese el número correctamente")]
        public long Celular { get; set; }


        [Required(ErrorMessage = "Por favor, ingrese el RNC correctamente")]
        public string? RNC { get; set; }


        [Required(ErrorMessage = "Por favor, complete el campo")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Por favor, ingrese su dirección")]
        public string? Direccion { get; set; }
    } 
}