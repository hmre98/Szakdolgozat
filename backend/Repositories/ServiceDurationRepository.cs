using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Contracts.Repository;

namespace backend.Repositories
{
    public class ServiceDurationRepository : BaseRepository<ServiceDuration>, IServiceDurationRepository
    {
        private readonly AppDbContext _context;

        public ServiceDurationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}