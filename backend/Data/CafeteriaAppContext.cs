using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data;

public class CafeteriaAppContext : DbContext
{
    public CafeteriaAppContext(DbContextOptions<CafeteriaAppContext> options) : base(options)
    {
    }

    public DbSet<Cafe> Cafes { get; set; }

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
    }
}

