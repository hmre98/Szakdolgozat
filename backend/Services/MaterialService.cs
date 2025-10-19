using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Repositories;

namespace backend.Services
{
    public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _repository;

    public MaterialService(IMaterialRepository repository)
    {
        _repository = repository;
    }

    public async Task<Material?> GetMaterialAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IQueryable<Material>> GetAllAsQueryableAsync()
    {
        var materials = await _repository.GetAllAsync();
        return materials.AsQueryable();
    }

    public async Task AddMaterialAsync(Material material)
    {
        await _repository.AddAsync(material);
    }

    public async Task UpdateMaterialAsync(Material material)
    {
        await _repository.UpdateAsync(material);
    }

    public async Task DeleteMaterialAsync(int id)
    {
        var material = await _repository.GetByIdAsync(id);
        if (material != null)
            await _repository.DeleteAsync(material);
    }
}
}