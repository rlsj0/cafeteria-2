namespace CafeteriaApp.Models;

public class CafeQueryParameters
{
    public string? Variedad { get; set; }
    public string? Tipo { get; set; }
    public string? OrderBy { get; set; }
    public bool Desc { get; set; } = false;
}

