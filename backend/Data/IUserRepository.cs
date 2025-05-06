using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public interface IUserRepository
{
    public Usuario AddUsuarioFromCredentials(string correo, string hash, byte[] salt);
    public Usuario GetUsuarioByEmail(string correo);
    public Usuario GetUsuarioById(int id);
    public IEnumerable<Usuario> GetUsuarios();
    public void SaveChanges();
}

