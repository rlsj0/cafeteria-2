using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public class UserRepository : IUserRepository
{

    private readonly CafeteriaAppContext _context;

    public UserRepository(CafeteriaAppContext context)
    {
        _context = context;
    }

    public Usuario AddUsuarioFromCredentials(string correo, string hash, byte[] salt)
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
            SaltContrasena = salt,
            Rol = Roles.Cliente,
            FechaCreacion = DateTime.Now
        };

        _context.Add(user);
        _context.SaveChanges();

        return user;
    }

    public Usuario GetUsuarioByEmail(string correo)
    {
        var user = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);
        if (user is null)
        {
            throw new KeyNotFoundException("Usuario no encontrado");
        }
        return user;
    }

    public Usuario GetUsuarioById(int id)
    {
        var user = _context.Usuarios.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            throw new KeyNotFoundException("Usuario no encontrado");
        }
        return user;
    }

    public IEnumerable<Usuario> GetUsuarios()
    {
        var query = _context.Usuarios.AsQueryable();
        var result = query.ToList();
        return result;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
