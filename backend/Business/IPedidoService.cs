using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface IPedidoService
{
    public IEnumerable<Pedido> GetAllPedidos();
    public IEnumerable<Pedido> GetPedidosByUser(int userId);
    public Pedido GetPedidoById(int id);
    public Pedido GetPedidoByUserAndId(int usuarioId, int pedidoId);

    public Pedido CreatePedido(PedidoCreateDto pedidoCreateDto);
}

