using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface IPedidoService
{
    public IEnumerable<PedidoReadDto> GetAllPedidos();
    public IEnumerable<PedidoReadDto> GetPedidosByUser(int userId);
    public PedidoReadDto GetPedidoById(int id);
    public PedidoReadDto GetPedidoByUserAndId(int usuarioId, int pedidoId);

    public Pedido CreatePedido(int userId, PedidoCreateDto pedidoCreateDto);
}

