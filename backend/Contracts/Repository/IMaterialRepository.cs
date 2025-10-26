using backend.Models;

namespace backend.Contracts.Repository
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<Material> GetMaterialsByNameAsync(string name);
    }
}