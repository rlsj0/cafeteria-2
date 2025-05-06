using CafeteriaApp.Data;
using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;

    public PedidoService(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public Pedido CreatePedido(PedidoCreateDto pedidoCreateDto)
    {
        var pedido = new Pedido
        {
            Usuario = pedidoCreateDto.usuario,
            UsuarioId = pedidoCreateDto.usuario.Id,
            PedidoDetalles = pedidoCreateDto.PedidoDetalles,
            ClienteSatisfecho = pedidoCreateDto.ClienteSatisfecho
        };
        _repository.AddPedido(pedido);
        _repository.SaveChanges();
        return pedido;
    }

    public IEnumerable<Pedido> GetAllPedidos()
    {
        // TODO: meter aquí parámetros de búsqueda (fecha de inicio/fin)
        // TODO: meter autorización
        return _repository.GetAllPedidos();
    }

    public Pedido GetPedidoById(int id)
    {
        var pedido = _repository.GetPedidoById(id);
        if (pedido == null)
        {
            throw new KeyNotFoundException($"No hay pedidos con el id {id}");
        }
        return pedido;
    }

    public Pedido GetPedidoByUserAndId(int usuarioId, int pedidoId)
    {
        var pedido = _repository.GetPedidoByUserAndId(usuarioId, pedidoId);
        if (pedido == null)
        {
            throw new KeyNotFoundException($"No se ha encontrado el pedido {pedidoId} del usuario {usuarioId}");
        }
        return pedido;
    }

    public IEnumerable<Pedido> GetPedidosByUser(int userId)
    {
        var pedido = _repository.GetPedidoByUserId(userId);
        if (pedido == null)
        {
            throw new KeyNotFoundException($"No hay pedidos con el id de usuario {userId}");
        }
        return pedido;
    }
}
