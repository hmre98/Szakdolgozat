using backend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using backend.DTOs;

namespace backend.Contracts.Repository
{
    public interface IUserRepository 
    {
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
        Task AddClaimAsync(ApplicationUser user, Claim claim);
        Task RemoveClaimAsync(ApplicationUser user, Claim claim);
        Task<IList<ApplicationUser>> GetAllAsync(PaginationDTO pagination);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<int> GetTotalCountAsync();


    }
}
