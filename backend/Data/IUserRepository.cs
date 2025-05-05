using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public interface IUserRepository
{
    public Usuario AddUserFromCredentials(string correo, string hash, byte[] salt);
    public Usuario GetUserByEmail(string correo);
    public void SaveChanges();
}

