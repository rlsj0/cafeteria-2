using CafeteriaApp.Business;
using CafeteriaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public IActionResult Login(UsuarioCreateDto usuarioCreateDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = _authService.Login(usuarioCreateDto);
            return Ok(token);
        }
        catch (KeyNotFoundException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest("Error generando el token: " + ex.Message);
        }
    }

    [HttpPost("Register")]
    public IActionResult Register(UsuarioCreateDto usuarioCreateDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = _authService.Register(usuarioCreateDto);
            return Ok(token);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

