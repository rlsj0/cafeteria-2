namespace Models;

public abstract class Producto
{
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

    public Producto(int id, decimal precio, int cantidadStock, int numeroCompras, bool esComercioJusto)
    {
        Id = id;
        Precio = precio;
        CantidadStock = cantidadStock;
        NumeroCompras = numeroCompras;
        EsComercioJusto = esComercioJusto;
    }

    // public abstract void SumarStock(int numero);
    // public abstract void RestarStock(int numero);
    // public abstract void MostrarInformacion();
}
