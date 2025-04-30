// using System.Security.Cryptography;
// using System.Text;

namespace Models;

public class Usuario
{

    public int Id { get; set; }
    public static int nextId { get; set; } = 0;
    public string Correo { get; set; }
    public string HashContrasena { get; set; }
    public byte[] SaltContrasena { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string Rol { get; set; }
    public List<Pedido>? HistoricoPedidos { get; set; }

    // Constructor vacio
    public Usuario() { }

    // Constructor para la creación de nuevo usuario
    // public Usuario(string correo, string contrasena, string rol)
    // {
    //     Id = ++nextId;
    //     Correo = correo;
    //     Rol = rol;
    //
    //     SaltContrasena = RandomNumberGenerator.GetBytes(64);
    //     HashContrasena = GenerarHash(contrasena);
    //     FechaCreacion = DateTime.Now;
    // }

    // Constructor entero
    public Usuario(int id, string correo, string hashContrasena, byte[] saltContrasena, DateTime fechaCreacion, String rol, List<Pedido> historicoPedidos)
    {
        Id = id;
        Correo = correo;
        HashContrasena = hashContrasena;
        SaltContrasena = saltContrasena;
        FechaCreacion = fechaCreacion;
        Rol = rol;
        HistoricoPedidos = historicoPedidos;

        if (nextId <= id)
        {
            nextId = id;
        }
    }
    // Crear un hash a partir de la contrasena usando `Rfc2898DeriveBytes`
    // Referencia: https://code-maze.com/csharp-hashing-salting-passwords-best-practices/
    // private string GenerarHash(string contrasena)
    // {
    //     int keySize = 64;
    //     int iterations = 1000;
    //     HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
    //
    //     var hash = Rfc2898DeriveBytes.Pbkdf2(
    //             Encoding.UTF8.GetBytes(contrasena),
    //             SaltContrasena,
    //             iterations,
    //             hashAlgorithm,
    //             keySize);
    //
    //     return Convert.ToHexString(hash);
    // }
    //
    // public bool CompararHash(string contrasena)
    // {
    //     string hash = GenerarHash(contrasena);
    //
    //     if (hash == HashContrasena)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }
    //
    // public List<Cafe> BuscarCafe(string buscar, List<Cafe> cafes)
    // {
    //     List<Cafe> resultado = new List<Cafe>();
    //     foreach (Cafe cafe in cafes)
    //     {
    //         if (cafe.Variedad.ToLower().Contains(buscar.ToLower()) | cafe.Tipo.ToLower().Contains(buscar.ToLower()))
    //         {
    //             resultado.Add(cafe);
    //         }
    //     }
    //
    //     if (resultado == null || !resultado.Any())
    //     {
    //         Console.WriteLine("No hay resultados...");
    //         return new List<Cafe>();
    //     }
    //     return resultado;
    // }
}
