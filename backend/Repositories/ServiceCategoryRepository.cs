using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Contracts.Repository;

namespace backend.Repositories
{
    public class ServiceCategoryRepository : BaseRepository<ServiceCategory>, IServiceCategoryRepository
    {
        private readonly AppDbContext _context;

        public ServiceCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

      
    }
}
