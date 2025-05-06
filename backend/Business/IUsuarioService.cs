using System.Security.Claims;
using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface IUsuarioService
{
    public UsuarioReadDto GetUsuarioById(int id);
    public IEnumerable<UsuarioReadDto> GetAllUsuarios();
    public bool EsAdmin(ClaimsPrincipal user);
    public bool TieneAcceso(int userId, ClaimsPrincipal user);
}

