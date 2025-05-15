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

    public Pedido CreatePedido(int userId, PedidoCreateDto pedidoCreateDto)
    {

        decimal precioTotal = 0;
        var pedidoDetalles = new List<PedidoDetalle>();

        if (pedidoCreateDto.PedidoDetallesCreateDto == null
            || !pedidoCreateDto.PedidoDetallesCreateDto.Any())
        {
            throw new ArgumentException("El pedido debe tener al menos un producto.");
        }

        // Para cada detalle hay que hacer una consulta en el repositorio

        foreach (var detalle in pedidoCreateDto.PedidoDetallesCreateDto)
        {
            var cafe = _cafeRepository.GetCafe(detalle.CafeId);

            if (cafe.CantidadStock < detalle.Cantidad)
            {
                throw new Exception("No hay tantos productos disponibles.");
            }

            var precio = cafe.Precio * detalle.Cantidad;

            precioTotal = precioTotal + precio;
            cafe.CantidadStock = cafe.CantidadStock - detalle.Cantidad;
            _cafeRepository.SaveChanges();

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
            UsuarioId = userId,
            PedidoDetalles = pedidoDetalles,
            ClienteSatisfecho = pedidoCreateDto.ClienteSatisfecho,
            PrecioTotal = precioTotal,
            Fecha = DateTime.Now
        };

        _pedidoRepository.AddPedido(pedido);
        _pedidoRepository.SaveChanges();
        return pedido;
    }

    public IEnumerable<PedidoReadDto> GetAllPedidos()
    {
        var pedidos = _pedidoRepository.GetAllPedidos();

        var pedidosDto = new List<PedidoReadDto>();

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

            var pedidoDto = new PedidoReadDto()
            {
                Id = pedido.Id,
                UsuarioId = pedido.UsuarioId,
                ClienteSatisfecho = pedido.ClienteSatisfecho,
                PedidoDetallesCreateDto = listaDetalleDto,
                PrecioTotal = pedido.PrecioTotal,
                Fecha = pedido.Fecha
            };
            pedidosDto.Add(pedidoDto);
        }

        return pedidosDto;
    }

    public PedidoReadDto GetPedidoById(int id)
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

        var pedidoDto = new PedidoReadDto()
        {
            Id = pedido.Id,
            UsuarioId = pedido.UsuarioId,
            ClienteSatisfecho = pedido.ClienteSatisfecho,
            PedidoDetallesCreateDto = listaDetalleDto,
            PrecioTotal = pedido.PrecioTotal,
            Fecha = pedido.Fecha
        };

        return pedidoDto;
    }

    public PedidoReadDto GetPedidoByUserAndId(int usuarioId,
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

        var pedidoDto = new PedidoReadDto()
        {
            Id = pedido.Id,
            UsuarioId = pedido.UsuarioId,
            ClienteSatisfecho = pedido.ClienteSatisfecho,
            PedidoDetallesCreateDto = listaDetalleDto,
            PrecioTotal = pedido.PrecioTotal,
            Fecha = pedido.Fecha
        };

        return pedidoDto;
    }

    public IEnumerable<PedidoReadDto> GetPedidosByUser(int userId)
    {
        var pedidos = _pedidoRepository.GetPedidoByUserId(userId);
        if (pedidos == null)
        {
            throw new KeyNotFoundException($"No hay pedidos con el id de usuario {userId}");
        }

        var pedidosDto = new List<PedidoReadDto>();

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

            var pedidoDto = new PedidoReadDto()
            {
                Id = pedido.Id,
                UsuarioId = pedido.UsuarioId,
                ClienteSatisfecho = pedido.ClienteSatisfecho,
                PedidoDetallesCreateDto = listaDetalleDto,
                PrecioTotal = pedido.PrecioTotal,
                Fecha = pedido.Fecha
            };
            pedidosDto.Add(pedidoDto);
        }

        return pedidosDto;
    }
}
