using System.ComponentModel.DataAnnotations;

namespace Models;

public abstract class Producto
{
    [Key]
    public int Id { get; set; }
    public decimal Precio { get; set; }
    public int CantidadStock { get; set; }
    public int NumeroCompras { get; set; }
    public bool EsComercioJusto { get; set; }


    public Producto() { }

    // // Constructor para crear un nuevo producto
    // public Producto(decimal precio, int cantidadStock, bool esComercioJusto)
    // {
    //     Id = ++nextId;
    //     Precio = precio;
    //     CantidadStock = cantidadStock;
    //     NumeroCompras = 0;
    //     EsComercioJusto = esComercioJusto;
    // }
    //

    // No hace falta que el pase el ID, ya se encarga EF de crearlo
    public Producto(decimal precio,
                    int cantidadStock,
                    int numeroCompras,
                    bool esComercioJusto)
    {
        Precio = precio;
        CantidadStock = cantidadStock;
        NumeroCompras = numeroCompras;
        EsComercioJusto = esComercioJusto;
    }

    // public abstract void SumarStock(int numero);
    // public abstract void RestarStock(int numero);
    // public abstract void MostrarInformacion();
}
