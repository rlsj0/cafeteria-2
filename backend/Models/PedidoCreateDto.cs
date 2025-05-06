namespace CafeteriaApp.Models;

public class PedidoCreateDto
{
    public int UsuarioId { get; set; }

    public ICollection<PedidoDetalleCreateDto> PedidoDetallesCreateDto { get; set; }

    public bool ClienteSatisfecho { get; set; }
}

