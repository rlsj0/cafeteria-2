using System.ComponentModel.DataAnnotations;

namespace CafeteriaApp.Models;

public class UsuarioCreateDto
{

    [Required]
    [EmailAddress]
    public string Correo { get; set; }

    [Required]
    [MinLength(6)]
    public string Contrasena { get; set; }

}

