namespace CafeteriaApp.Models;

public class PedidoReadDto
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public ICollection<PedidoDetalleCreateDto> PedidoDetallesCreateDto { get; set; }

    public bool ClienteSatisfecho { get; set; }

    public decimal PrecioTotal { get; set; }

    public DateTime Fecha { get; set; }
}

