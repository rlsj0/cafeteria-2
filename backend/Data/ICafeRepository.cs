using CafeteriaApp.Models;

namespace CafeteriaApp.Data;

public interface ICafeRepository
{

    public IEnumerable<Cafe> GetAllCafes();
    public Cafe GetCafe(int id);
    public void AddCafe(Cafe cafe);
    public void UpdateCafe(Cafe cafe);
    public void DeleteCafe(int id);

    public void SaveChanges();
}

