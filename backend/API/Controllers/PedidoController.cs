using CafeteriaApp.Business;
using CafeteriaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ILogger<PedidoController> _logger;
    // TODO: usar el logger abajo, por ejemplo para POST, PUT y DELETE
    private readonly IPedidoService _pedidoService;


    public PedidoController(ILogger<PedidoController> logger,
                          IPedidoService pedidoService)
    {
        _logger = logger;
        _pedidoService = pedidoService;
    }

    [HttpGet(Name = "GetAllPedidos")]
    public ActionResult<IEnumerable<Pedido>> GetAllPedidos()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var pedidos = _pedidoService.GetAllPedidos();
            return Ok(pedidos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("{id}", Name = "GetPedido")]
    public IActionResult GetPedido(int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedido = _pedidoService.GetPedidoById(id);
            return Ok(pedido);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"El pedido de id {id} no existe");
        }
    }
}

