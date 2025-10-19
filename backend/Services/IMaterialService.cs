using backend.Models;
using backend.Data;

namespace backend.Services
{
public interface IMaterialService
{
    Task<Material?> GetMaterialAsync(int id);
    Task<IEnumerable<Material>> GetAllMaterialsAsync();
    Task<IQueryable<Material>> GetAllAsQueryableAsync();
    Task AddMaterialAsync(Material material);
    Task UpdateMaterialAsync(Material material);
    Task DeleteMaterialAsync(int id);
}

}