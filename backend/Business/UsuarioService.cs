using System.Security.Claims;
using CafeteriaApp.Data;
using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public class UsuarioService : IUsuarioService
{
    private readonly IUserRepository _repository;

    public UsuarioService(IUserRepository repository)
    {
        _repository = repository;
    }

    public bool EsAdmin(ClaimsPrincipal user)
    {
        var rol = user.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Role);

        if (rol == null)
        {
            return false;
        }

        var claimValue = rol.Value;

        return claimValue == Roles.Admin;
    }

    public IEnumerable<UsuarioReadDto> GetAllUsuarios()
    {
        // Select es el equivalente en C# a map
        var listaDto = _repository.GetUsuarios().Select(usuario => new UsuarioReadDto
        {
            Id = usuario.Id,
            Correo = usuario.Correo,
            Rol = usuario.Rol
        });
        return listaDto;
    }

    public UsuarioReadDto GetUsuarioById(int id)
    {
        var usuario = _repository.GetUsuarioById(id);
        if (usuario == null)
        {
            throw new KeyNotFoundException($"No hay usuarios con el id {id}");
        }

        var usuarioDto = new UsuarioReadDto
        {
            Id = usuario.Id,
            Correo = usuario.Correo,
            Rol = usuario.Rol
        };

        return usuarioDto;
    }

    // Verificar que la id del user coincide con la del recurso que nos pide
    public bool TieneAcceso(int userId, ClaimsPrincipal user)
    {
        var claimId = user.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier);

        if (claimId == null || !int.TryParse(claimId.Value, out int resultado))
        {
            throw new UnauthorizedAccessException();
        }

        var esElUsuario = userId == resultado;

        return EsAdmin(user) || esElUsuario;
    }
}
