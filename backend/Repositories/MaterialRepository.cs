using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Contracts.Repository;

namespace backend.Repositories;

   public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
{
    private readonly AppDbContext _context;

    public MaterialRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

      public async Task<Material> GetMaterialsByNameAsync(string name)
  {
      return await _context.Materials
          .Where(a => a.Name == name)
          .FirstOrDefaultAsync();
  }
   
}