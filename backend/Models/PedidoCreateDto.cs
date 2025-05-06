namespace CafeteriaApp.Models;

public class PedidoCreateDto
{
    // No ponemos Id porque queremos sacarlo del JWT

    public ICollection<PedidoDetalleCreateDto> PedidoDetallesCreateDto { get; set; }

    public bool ClienteSatisfecho { get; set; }
}

