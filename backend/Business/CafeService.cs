using CafeteriaApp.Models;
using CafeteriaApp.Data;

namespace CafeteriaApp.Business;

public class CafeService : ICafeService
{
    private readonly ICafeRepository _repository;

    public CafeService(ICafeRepository repository)
    {
        _repository = repository;
    }

    // Create
    public Cafe CreateCafe(CafeCreateDto cafe)
    {
        var numeroCompras = 0;
        var nuevoCafe = new Cafe(cafe.Precio,
                                 cafe.CantidadStock,
                                 numeroCompras,
                                 cafe.EsComercioJusto,
                                 cafe.Variedad,
                                 cafe.Tipo);
        // TODO: añadir en repositorio la movida del id
        _repository.AddCafe(nuevoCafe);
        _repository.SaveChanges();
        // TODO: ojo porque se está devolviendo un cafe sin id
        return nuevoCafe;
    }

    // Read
    // TODO: meter parámetros de búsqueda
    public IEnumerable<Cafe> GetAllCafes()
    {
        return _repository.GetAllCafes();
    }

    public Cafe GetCafeById(int id)
    {
        var cafe = _repository.GetCafe(id);
        if (cafe == null)
        {
            throw new KeyNotFoundException($"No hay cafés con el id {id}");
        }
        return cafe;
    }

    // Update
    public void UpdateCafe(int id, CafeCreateDto crearCafe)
    {
        var cafe = _repository.GetCafe(id);

        if (cafe == null)
        {
            throw new KeyNotFoundException($"No hay cafés con el id {id}");
        }

        cafe.Precio = crearCafe.Precio;
        cafe.CantidadStock = crearCafe.CantidadStock;
        cafe.EsComercioJusto = crearCafe.EsComercioJusto;
        cafe.Variedad = crearCafe.Variedad;
        cafe.Tipo = crearCafe.Tipo;
        // Id y NumeroCompras  no se modifican

        // Como hemos cogido a "cafe" del contexto, al modificarlo aquí
        // lo modificamos en la tabla. No hace falta:
        //_repository.UpdateCafe(cafe);
        _repository.SaveChanges();
    }

    // Delete
    public void DeleteCafe(int id)
    {
        var cafe = _repository.GetCafe(id);
        if (cafe == null)
        {
            throw new KeyNotFoundException($"No hay cafés con el id {id}");
        }

        _repository.DeleteCafe(id);
        _repository.SaveChanges();
    }
}

