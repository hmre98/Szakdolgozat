using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Contracts.Repository;

namespace backend.Repositories;
   public class ServiceMaterialRepository : BaseRepository<ServiceMaterial>, IServiceMaterialRepository
{
    private readonly AppDbContext _context;

    public ServiceMaterialRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ServiceMaterial?> GetByIdAsync(int id)
    {
        return await _context.ServiceMaterials
            .Include(sm => sm.Material)
            .Include(sm => sm.Service)
            .FirstOrDefaultAsync(sm => sm.Id == id);
    }

    public async Task<IEnumerable<ServiceMaterial>> GetByServiceIdAsync(int serviceId)
    {
        return await _context.ServiceMaterials
            .Include(sm => sm.Material)
            .Where(sm => sm.ServiceId == serviceId)
            .ToListAsync();
    }

    public async Task AddAsync(ServiceMaterial serviceMaterial)
    {
        await _context.ServiceMaterials.AddAsync(serviceMaterial);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ServiceMaterial serviceMaterial)
    {
        _context.ServiceMaterials.Remove(serviceMaterial);
        await _context.SaveChangesAsync();
    }
}