using Models;

namespace Business;

public interface ICafeService
{
    // Create
    public Cafe CreateCafe(CafeCreateDto cafe);

    // Read
    public IEnumerable<Cafe> GetAllCafes();
    public Cafe GetAllCafeById(int id);

    // Update
    public void UpdateCafe(int id, CafeCreateDto cafe);

    // Delete
    public void DeleteCafe(int id);
}

