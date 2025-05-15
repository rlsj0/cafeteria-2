using System.Security.Claims;
using CafeteriaApp.Models;

namespace CafeteriaApp.Business;

public interface ICafeService
{
    // Create
    public Cafe CreateCafe(CafeCreateDto cafe);

    // Read
    public IEnumerable<Cafe> GetAllCafes(CafeQueryParameters query);
    public Cafe GetCafeById(int id);

    // Update
    public void UpdateCafe(int id, CafeCreateDto cafe);

    // Delete
    public void DeleteCafe(int id);

    // Autorizar
    public bool EsAdmin(ClaimsPrincipal user);
}

