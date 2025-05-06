using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface IPedidoService
{
    public IEnumerable<PedidoCreateDto> GetAllPedidos();
    public IEnumerable<PedidoCreateDto> GetPedidosByUser(int userId);
    public PedidoCreateDto GetPedidoById(int id);
    public PedidoCreateDto GetPedidoByUserAndId(int usuarioId, int pedidoId);

    public Pedido CreatePedido(PedidoCreateDto pedidoCreateDto);
}

