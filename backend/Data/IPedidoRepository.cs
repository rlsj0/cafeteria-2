using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public interface IPedidoRepository
{
    public void AddPedido(Pedido pedido);

    public IEnumerable<Pedido> GetAllPedidos();
    public IEnumerable<Pedido> GetPedidoByUserId(int userId);
    public Pedido GetPedidoById(int id);

    public void SaveChanges();
}

