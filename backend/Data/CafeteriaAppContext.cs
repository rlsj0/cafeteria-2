using CafeteriaApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CafeteriaApp.Data;

public class CafeteriaAppContext : DbContext
{
    public CafeteriaAppContext(DbContextOptions<CafeteriaAppContext> options) : base(options)
    {
    }

    public DbSet<Cafe> Cafes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cafe>().HasData(
            new Cafe
            {
                Id = 1,
                Precio = 1.1m,
                CantidadStock = 4,
                NumeroCompras = 3,
                EsComercioJusto = true,
                Variedad = "Nigeria",
                Tipo = "Café solo"
            },
            new Cafe
            {
                Id = 2,
                Precio = 1.0m,
                CantidadStock = 4,
                NumeroCompras = 3,
                EsComercioJusto = true,
                Variedad = "Brasil",
                Tipo = "Café solo"
            }
        );
        modelBuilder.Entity<Usuario>().HasData(
            // Contrasena: password
            new Usuario
            {
                Id = -1,
                Correo = "admin@gmail.com",
                HashContrasena = "DA6E5F37539A6CC32BC1A519D08B4A5BB012E23A47EB002CF719F081ABC9B463A8FB15728D7E103AB9AA94445B92E794B4C2456EDE79432C9DD508A6856471AF",
                SaltContrasena = Convert.FromHexString("06B486D160583C77830194A3B25A1402FD1B4875E81A52E218CA5AD5BAB3730B923A7109AF40F69E5036DC7111172CE533CA3AEE31DEFEDAD9CA0890BA01198F"),
                Rol = Roles.Admin
            }
        );
    }
}

