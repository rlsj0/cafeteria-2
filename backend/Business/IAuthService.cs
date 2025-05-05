using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface IAuthService
{
    public string Login(UsuarioCreateDto usuarioCreateDto);
    public string Register(UsuarioCreateDto usuarioCreateDto);
    public byte[] GenerateSalt();
    public string HashPassword(string contrasena, byte[] salt);
    public string GenerateToken(UsuarioReadDto usuarioReadDto);
    public string VerificarAcceso(int id);
}

