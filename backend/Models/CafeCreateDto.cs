using System.ComponentModel.DataAnnotations;

namespace CafeteriaApp.Models;

public class CafeCreateDto
{

    [Required]
    public decimal Precio { get; set; }

    [Required]
    public int CantidadStock { get; set; }

    [Required]
    public string Variedad { get; set; }

    [Required]
    public string Tipo { get; set; }

    [Required]
    public bool EsComercioJusto { get; set; }
}

