using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface IUsuarioService
{
    public UsuarioReadDto GetUsuarioById(int id);
    public IEnumerable<UsuarioReadDto> GetAllUsuarios();
}

