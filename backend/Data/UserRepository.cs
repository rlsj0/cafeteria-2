using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public class UserRepository : IUserRepository
{

    private readonly CafeteriaAppContext _context;

    public UserRepository(CafeteriaAppContext context)
    {
        _context = context;
    }

    public Usuario AddUserFromCredentials(string correo, string hash, byte[] salt)
    {
        // Primero chequear que el correo no se esté usando ya (devolver excepción)
        if (_context.Usuarios.Any(u => u.Correo == correo))
        {
            throw new InvalidOperationException("Ya existe un usuario con ese correo.");
        }
        // Luego coger de la base de datos
        var user = new Usuario
        {
            Correo = correo,
            HashContrasena = hash,
            SaltContrasena = salt
        };

        _context.Add(user);
        _context.SaveChanges();

        return user;
    }

    public Usuario GetUserByEmail(string correo)
    {
        var user = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);
        if (user is null)
        {
            throw new KeyNotFoundException("Usuario no encontrado");
        }
        return user;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
