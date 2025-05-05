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

    public IEnumerable<Pedido> GetPedidosByUser(Usuario user)
    {
        var pedido = _repository.GetPedidoByUserId(user.Id);
        if (pedido == null)
        {
            throw new KeyNotFoundException($"No hay pedidos con el id de usuario {user.Id}");
        }
        return pedido;
    }
}
