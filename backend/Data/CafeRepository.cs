using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public class CafeRepository : ICafeRepository
{

    private readonly CafeteriaAppContext _context;

    public CafeRepository(CafeteriaAppContext context)
    {
        _context = context;
    }

    public IEnumerable<Cafe> GetAllCafes()
    {
        var query = _context.Cafes.AsQueryable();

        // TODO: meter filtros

        var result = query.ToList();

        return result;
    }

    public Cafe GetCafe(int id)
    {
        var cafe = _context.Cafes.FirstOrDefault(cafe => cafe.Id == id);
        if (cafe is null)
        {
            throw new KeyNotFoundException("Café no encontrado");
        }
        return cafe;
    }

    public void AddCafe(Cafe cafe)
    {
        _context.Cafes.Add(cafe);
    }

    public void UpdateCafe(Cafe cafe)
    {
        _context.Cafes.Remove(cafe);
        SaveChanges();
    }

    public void DeleteCafe(int id)
    {
        var cafe = GetCafe(id);
        if (cafe is null)
        {
            throw new KeyNotFoundException("Cafe no encontrado");
        }
        _context.Cafes.Remove(cafe);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}

