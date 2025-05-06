using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public class CafeRepository : ICafeRepository
{

    private readonly CafeteriaAppContext _context;

    public CafeRepository(CafeteriaAppContext context)
    {
        _context = context;
    }

    public IEnumerable<Cafe> GetAllCafes(CafeQueryParameters queryParams)
    {
        var query = _context.Cafes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryParams.Variedad))
        {
            query = query.Where(c => c.Variedad.ToLower().Contains(queryParams.Variedad.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(queryParams.Tipo))
        {
            query = query.Where(c => c.Tipo.ToLower().Contains(queryParams.Tipo.ToLower()));
        }

        if (!string.IsNullOrWhiteSpace(queryParams.OrderBy))
        {
            switch (queryParams.OrderBy)
            {
                case "precio":
                    query = queryParams.Desc
                        ? query.OrderByDescending(c => c.Precio)
                        : query.OrderBy(c => c.Precio);
                    break;
                case "id":
                    query = queryParams.Desc
                        ? query.OrderByDescending(c => c.Id)
                        : query.OrderBy(c => c.Id);
                    break;
                default:
                    break;
            }
        }

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

