using System.ComponentModel.DataAnnotations;

namespace CafeteriaApp.Models;

public class PedidoDetalle
{
    public int Id { get; set; }

    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; }

    public int CafeId { get; set; }
    public Cafe Cafe { get; set; }

    public int Cantidad { get; set; }
}
