using CafeteriaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApp.Data;

public class PedidoRepository : IPedidoRepository
{
    private readonly CafeteriaAppContext _context;

    public PedidoRepository(CafeteriaAppContext context)
    {
        _context = context;
    }

    public void AddPedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
    }

    public IEnumerable<Pedido> GetAllPedidos()
    {
        var result = _context.Pedidos.Include(p => p.PedidoDetalles)
                                     .ThenInclude(pd => pd.Cafe)
                                     .Include(p => p.Usuario)
                                     .ToList();

        // var query = _context.Pedidos.AsQueryable();

        // TODO: meter filtros

        // var result = query.ToList();

        return result;
    }

    public Pedido GetPedidoById(int id)
    {
        var pedidos = _context.Pedidos.Include(p => p.PedidoDetalles)
            .ThenInclude(pd => pd.Cafe)
            .Include(p => p.Usuario);

        var pedido = pedidos.FirstOrDefault(pedido => pedido.Id == id);

        if (pedido is null)
        {
            throw new KeyNotFoundException("Pedido no encontrado");
        }

        return pedido;
    }

    public Pedido GetPedidoByUserAndId(int usuarioId, int pedidoId)
    {
        var pedidos = _context.Pedidos.Include(p => p.PedidoDetalles)
            .ThenInclude(pd => pd.Cafe)
            .Include(p => p.Usuario);

        var pedido = pedidos.FirstOrDefault(pedido => pedido.Id == pedidoId && pedido.UsuarioId == usuarioId);

        if (pedido is null)
        {
            throw new KeyNotFoundException("Pedido no encontrado");
        }
        return pedido;
    }

    public IEnumerable<Pedido> GetPedidoByUserId(int userId)
    {
        var pedidos = _context.Pedidos.Include(p => p.PedidoDetalles)
                                      .ThenInclude(pd => pd.Cafe)
                                      .Include(p => p.Usuario)
                                      .Where(pedido => pedido.UsuarioId == userId);

        if (pedidos is null || !pedidos.Any())
        {
            throw new KeyNotFoundException("Ningún pedido asociado con esa id de usuario.");
        }

        var result = pedidos.ToList();
        return result;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
