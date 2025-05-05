using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface IPedidoService
{
    public IEnumerable<Pedido> GetAllPedidos();
    public IEnumerable<Pedido> GetPedidosByUser(Usuario user);
    public Pedido GetPedidoById(int id);

    public Pedido CreatePedido(PedidoCreateDto pedidoCreateDto);
}

