using Models;
using Data;

namespace Business;

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
        var nuevoCafe = new Cafe(cafe.Precio,
                                 cafe.CantidadStock,
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

    public Cafe GetAllCafeById(int id)
    {
        var cafe = _repository.GetCafe(id);
        if (cafe == null)
        {
            throw new KeyNotFoundException($"No hay cafés con el id {id}");
        }
        return cafe;
    }

    // Update
    public void UpdateCafe(int id, CafeCreateDto cafe)
    {
        var account = _repository.GetAccount(id);

        if (account == null)
        {
            throw new KeyNotFoundException($"No hay cafés con el id {id}");
        }

        _repository.UpdateCafe(cafe);
        _repository.SaveChanges();
    }

    // Delete
    public void DeleteCafe(int id)
    {
        var account = _repository.GetAccount(id);
        if (account == null)
        {
            throw new KeyNotFoundException($"No hay cafés con el id {id}");
        }

        _repository.DeleteCafe(id);
        _repository.SaveChanges();
    }
}

