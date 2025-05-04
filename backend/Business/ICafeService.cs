using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface ICafeService
{
    // Create
    public Cafe CreateCafe(CafeCreateDto cafe);

    // Read
    public IEnumerable<Cafe> GetAllCafes();
    public Cafe GetCafeById(int id);

    // Update
    public void UpdateCafe(int id, CafeCreateDto cafe);

    // Delete
    public void DeleteCafe(int id);
}

