using CafeteriaApp.Data;
using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly ICafeRepository _cafeRepository;

    public PedidoService(IPedidoRepository pedidoRepository,
                         ICafeRepository cafeRepository)
    {
        _pedidoRepository = pedidoRepository;
        _cafeRepository = cafeRepository;
    }

    public Pedido CreatePedido(PedidoCreateDto pedidoCreateDto)
    {

        decimal precioTotal = 0;
        var pedidoDetalles = new List<PedidoDetalle>();
        Console.WriteLine("He llegado al servicio");

        if (pedidoCreateDto.PedidoDetallesCreateDto == null
            || !pedidoCreateDto.PedidoDetallesCreateDto.Any())
        {
            throw new ArgumentException("El pedido debe tener al menos un producto.");
        }

        // Para cada detalle hay que hacer una consulta en el repositorio

        foreach (var detalle in pedidoCreateDto.PedidoDetallesCreateDto)
        {
            var cafe = _cafeRepository.GetCafe(detalle.CafeId);
            Console.WriteLine("Cafe: " + detalle.CafeId + " = " + cafe.Id);
            var precio = cafe.Precio * detalle.Cantidad;

            precioTotal = precioTotal + precio;

            pedidoDetalles.Add(new PedidoDetalle
            {
                // Entiendo que no hace falta ponerle aquí el pedido
                CafeId = cafe.Id,
                Cafe = cafe,
                Cantidad = detalle.Cantidad
            });
        }

        var pedido = new Pedido
        {
            UsuarioId = pedidoCreateDto.UsuarioId,
            PedidoDetalles = pedidoDetalles,
            ClienteSatisfecho = pedidoCreateDto.ClienteSatisfecho,
            PrecioTotal = precioTotal,
            Fecha = DateTime.Now
        };

        _pedidoRepository.AddPedido(pedido);
        _pedidoRepository.SaveChanges();
        return pedido;
    }

    public IEnumerable<PedidoCreateDto> GetAllPedidos()
    {
        // TODO: meter aquí parámetros de búsqueda (fecha de inicio/fin)
        // TODO: meter autorización

        var pedidos = _pedidoRepository.GetAllPedidos();

        var pedidosDto = new List<PedidoCreateDto>();

        foreach (var pedido in pedidos)
        {
            var listaDetalleDto = new List<PedidoDetalleCreateDto>();

            foreach (var detalle in pedido.PedidoDetalles)
            {
                listaDetalleDto.Add(new PedidoDetalleCreateDto()
                {
                    CafeId = detalle.CafeId,
                    Cantidad = detalle.Cantidad
                });
            }

            var pedidoDto = new PedidoCreateDto()
            {
                UsuarioId = pedido.UsuarioId,
                ClienteSatisfecho = pedido.ClienteSatisfecho,
                PedidoDetallesCreateDto = listaDetalleDto
            };
            pedidosDto.Add(pedidoDto);
        }

        return pedidosDto;
    }

    public PedidoCreateDto GetPedidoById(int id)
    {
        var pedido = _pedidoRepository.GetPedidoById(id);
        if (pedido == null)
        {
            throw new KeyNotFoundException($"No hay pedidos con el id {id}");
        }

        var listaDetalleDto = new List<PedidoDetalleCreateDto>();

        foreach (var detalle in pedido.PedidoDetalles)
        {
            listaDetalleDto.Add(new PedidoDetalleCreateDto()
            {
                CafeId = detalle.CafeId,
                Cantidad = detalle.Cantidad
            });
        }

        var pedidoDto = new PedidoCreateDto()
        {
            UsuarioId = pedido.UsuarioId,
            ClienteSatisfecho = pedido.ClienteSatisfecho,
            PedidoDetallesCreateDto = listaDetalleDto
        };

        return pedidoDto;
    }

    public PedidoCreateDto GetPedidoByUserAndId(int usuarioId,
                                                int pedidoId)
    {
        var pedido = _pedidoRepository.GetPedidoByUserAndId(usuarioId, pedidoId);
        if (pedido == null)
        {
            throw new KeyNotFoundException($"No se ha encontrado el pedido {pedidoId} del usuario {usuarioId}");
        }

        var listaDetalleDto = new List<PedidoDetalleCreateDto>();

        foreach (var detalle in pedido.PedidoDetalles)
        {
            listaDetalleDto.Add(new PedidoDetalleCreateDto()
            {
                CafeId = detalle.CafeId,
                Cantidad = detalle.Cantidad
            });
        }

        var pedidoDto = new PedidoCreateDto()
        {
            UsuarioId = pedido.UsuarioId,
            ClienteSatisfecho = pedido.ClienteSatisfecho,
            PedidoDetallesCreateDto = listaDetalleDto
        };

        return pedidoDto;
    }

    public IEnumerable<PedidoCreateDto> GetPedidosByUser(int userId)
    {
        var pedidos = _pedidoRepository.GetPedidoByUserId(userId);
        if (pedidos == null)
        {
            throw new KeyNotFoundException($"No hay pedidos con el id de usuario {userId}");
        }

        var pedidosDto = new List<PedidoCreateDto>();

        foreach (var pedido in pedidos)
        {
            var listaDetalleDto = new List<PedidoDetalleCreateDto>();

            foreach (var detalle in pedido.PedidoDetalles)
            {
                listaDetalleDto.Add(new PedidoDetalleCreateDto()
                {
                    CafeId = detalle.CafeId,
                    Cantidad = detalle.Cantidad
                });
            }

            var pedidoDto = new PedidoCreateDto()
            {
                UsuarioId = pedido.UsuarioId,
                ClienteSatisfecho = pedido.ClienteSatisfecho,
                PedidoDetallesCreateDto = listaDetalleDto
            };
            pedidosDto.Add(pedidoDto);
        }

        return pedidosDto;
    }
}
