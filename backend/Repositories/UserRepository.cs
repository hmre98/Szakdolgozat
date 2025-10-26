using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using backend.Contracts.Repository;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            return await _userManager.GetClaimsAsync(user);
        }

        public async Task AddClaimAsync(ApplicationUser user, Claim claim)
        {
            await _userManager.AddClaimAsync(user, claim);
        }

        public async Task RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            await _userManager.RemoveClaimAsync(user, claim);
        }

        public async Task<IList<ApplicationUser>> GetAllAsync(PaginationDTO pagination)
        {
            var query = _userManager.Users
                               .OrderBy(u => u.UserName)
                               .Skip((pagination.Page - 1) * pagination.RecordsPerPage)
                               .Take(pagination.RecordsPerPage)
                               .ToListAsync();

            return await query;
        }
        
         public async Task<int> GetTotalCountAsync()
            {
                return await _userManager.Users.CountAsync();
            }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

    }
}
