namespace CafeteriaApp.Models;

public class PedidoCreateDto
{
    public Usuario usuario { get; set; }

    public ICollection<PedidoDetalle> PedidoDetalles { get; set; }

    public decimal PrecioTotal { get; set; }

    public bool ClienteSatisfecho { get; set; }
}

