using backend.Models;

namespace backend.Repositories
{
    public interface IMaterialRepository
    {
        Task<Material?> GetByIdAsync(int id);
        Task<IEnumerable<Material>> GetAllAsync();
        Task AddAsync(Material material);
        Task UpdateAsync(Material material);
        Task DeleteAsync(Material material);
    }
}