﻿using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;


namespace ProyectoManager.Models
{
    public class Clientes
    {
        [Key]
        public int ClientesId { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Ingrese el número celular correctamente")]
        public long Celular { get; set; }

        [Required(ErrorMessage = "Ingrese el teléfono correctamente")]
        public long Telefono { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el RNC correctamente")]
        public long RNC { get; set; }

        [Required(ErrorMessage = "Por favor, complete el campo")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese su dirección")]
        public string? Direccion { get; set; }
    } 
}