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
}
