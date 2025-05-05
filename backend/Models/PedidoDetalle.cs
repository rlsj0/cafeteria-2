using System.ComponentModel.DataAnnotations;

namespace CafeteriaApp.Models;

public class PedidoDetalle
{
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; }

    public int ProductoId { get; set; }
    public Producto Producto { get; set; }

    public int Cantidad { get; set; }
}
