using System.Security.Claims;
using CafeteriaApp.Business;
using CafeteriaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ILogger<PedidoController> _logger;
    // TODO: usar el logger abajo, por ejemplo para POST, PUT y DELETE
    private readonly IPedidoService _pedidoService;
    private readonly IUsuarioService _usuarioService;


    public PedidoController(ILogger<PedidoController> logger,
                          IPedidoService pedidoService,
                          IUsuarioService usuarioService)
    {
        _logger = logger;
        _pedidoService = pedidoService;
        _usuarioService = usuarioService;
    }

    [Authorize]
    [HttpGet(Name = "GetAllPedidos")]
    public ActionResult<IEnumerable<Pedido>> GetAllPedidos()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_usuarioService.EsAdmin(HttpContext.User))
            {
                return Unauthorized();
            }

            var pedidos = _pedidoService.GetAllPedidos();
            return Ok(pedidos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [Authorize]
    [HttpGet("{id}", Name = "GetPedido")]
    public IActionResult GetPedido(int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_usuarioService.EsAdmin(HttpContext.User))
            {
                return Unauthorized();
            }

            var pedido = _pedidoService.GetPedidoById(id);
            return Ok(pedido);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"El pedido de id {id} no existe");
        }
    }

    [Authorize]
    [HttpPost(Name = "HacerPedido")]
    public IActionResult HacerPedido(PedidoCreateDto pedidoCreateDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Cogiendo id del JWT
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var pedido = _pedidoService.CreatePedido(usuarioId, pedidoCreateDto);

            // Al solo devolver al id, no se serializa
            return Ok(pedido.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

