using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CafeteriaApp.Models;

public class Pedido
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; }

    public ICollection<PedidoDetalle> PedidoDetalles { get; set; }

    public decimal PrecioTotal { get; set; }

    public DateTime Fecha { get; set; }

    public bool ClienteSatisfecho { get; set; }

    public Pedido()
    {
        PedidoDetalles = new List<PedidoDetalle>();
    }

    // Igual no hace falta constructor
    // public Pedido(Usuario usuario,
    //               decimal precioTotal,
    //               DateTime fecha,
    //               bool clienteSatisfecho)
    // {
    //     Usuario = usuario;
    //     UsuarioId = usuario.Id;
    //     // Productos = productos;
    //     PrecioTotal = precioTotal;
    //     Fecha = fecha;
    //     ClienteSatisfecho = clienteSatisfecho;
    // }
    //
    // Constructor para crear nuevo pedido
    // public Pedido(int idCliente, List<Tuple<Cafe, int>> productos, bool clienteSatisfecho)
    // {
    //     Id = ++nextId;
    //     IdCliente = idCliente;
    //     Productos = productos;
    //     ClienteSatisfecho = clienteSatisfecho;
    //     Fecha = DateTime.Now;
    //
    //     PrecioTotal = CalcularPrecioTotal();
    // }

    // Constructor para cargar un pedido del json
    // [JsonConstructor]
    // public Pedido(int id, int idCliente, List<Tuple<Cafe, int>> productos, decimal precioTotal, DateTime fecha, bool clienteSatisfecho)
    // {
    //     Id = id;
    //     IdCliente = idCliente;
    //     Productos = productos;
    //     PrecioTotal = precioTotal;
    //     Fecha = fecha;
    //     ClienteSatisfecho = clienteSatisfecho;
    //
    //     if (nextId <= id)
    //     {
    //         nextId = id;
    //     }
    // }
    //
    // private decimal CalcularPrecioTotal()
    // {
    //     decimal precioTotal = 0;
    //     foreach (Tuple<Cafe, int> tupla in Productos)
    //     {
    //         decimal precioProducto = tupla.Item2 * tupla.Item1.Precio;
    //         precioTotal = precioTotal + precioProducto;
    //     }
    //     return precioTotal;
    // }
    //
    // public void MostrarDetalles()
    // {
    //     string fecha = Fecha.ToString("dd/MM/yyyy");
    //     string satisfaccion = ClienteSatisfecho ? "Sí" : "No";
    //     string texto = $"ID del pedido: {Id}\n\tID del cliente: {IdCliente}" +
    //         $"\n\tFecha: {fecha}\n\t¿Cliente satisfecho? {satisfaccion}" +
    //         $"\n\tProductos:";
    //     Console.WriteLine(texto);
    //
    //     foreach (Tuple<Cafe, int> tupla in Productos)
    //     {
    //         Console.WriteLine($"\t\t{tupla.Item1.Variedad}, {tupla.Item1.Tipo}: " +
    //                 $"{tupla.Item2} x {tupla.Item1.Precio:C}");
    //     }
    //     Console.WriteLine($"Precio total: {PrecioTotal:C}");
    // }
    //
}
