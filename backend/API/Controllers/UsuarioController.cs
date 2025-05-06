using CafeteriaApp.Models;
using CafeteriaApp.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CafeteriaApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    // TODO: usar el logger abajo, por ejemplo para POST, PUT y DELETE
    private readonly IPedidoService _pedidoService;
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(ILogger<UsuarioController> logger,
                          IPedidoService pedidoService,
                          IUsuarioService usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
        _pedidoService = pedidoService;
    }

    [Authorize]
    [HttpGet(Name = "GetAllUsuarios")]
    public ActionResult<IEnumerable<UsuarioReadDto>> GetAllUsuarios([FromQuery] UsuarioQueryParameteres query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!_usuarioService.EsAdmin(HttpContext.User))
        {
            return Unauthorized();
        }

        try
        {
            var usuarios = _usuarioService.GetAllUsuarios(query);
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [Authorize]
    [HttpGet("{id}", Name = "GetUsuario")]
    public IActionResult GetUsuario(int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_usuarioService.TieneAcceso(id, HttpContext.User))
            {
                return Unauthorized();
            }
            var usuario = _usuarioService.GetUsuarioById(id);
            return Ok(usuario);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"El usuario de id {id} no existe");
        }
    }

    // Ver pedidos de usuario
    [Authorize]
    [HttpGet("{id}/pedidos", Name = "GetUsuarioPedidos")]
    public IActionResult GetUsuarioPedidos(int id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_usuarioService.TieneAcceso(id, HttpContext.User))
            {
                return Unauthorized();
            }

            var pedidos = _pedidoService.GetPedidosByUser(id);
            return Ok(pedidos);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Ver pedido singular de usuario (usuario/id/pedidos/id)
    [Authorize]
    [HttpGet("{usuarioId}/pedidos/{pedidoId}", Name = "GetUsuarioPedido")]
    public IActionResult GetUsuarioPedidoSingular(int usuarioId,
                                                  int pedidoId)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_usuarioService.TieneAcceso(usuarioId, HttpContext.User))
            {
                return Unauthorized();
            }

            var pedido = _pedidoService.GetPedidoByUserAndId(usuarioId,
                                                             pedidoId);
            return Ok(pedido);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"No se han encontrado el pedido {pedidoId} del usuario {usuarioId}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

