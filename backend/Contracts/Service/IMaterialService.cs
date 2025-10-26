using backend.Models;
using backend.Data;
using backend.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using backend.Enums;

namespace backend.Contracts.Services
{
public interface IMaterialService
{
    Task<Material?> GetMaterialByNameAsync(string name);
    Task<PagedResult<MaterialDTO>> GetAllMaterialsAsync(int pageNumber, int pageSize, string sortColumn, SortDirection sortDirection);
    Task<int> UpdateMaterialByIdAsync(int id, MaterialDTO material);
    Task<Material> AddMaterialAsync(MaterialDTO material);

    Task<int> DeleteMaterialAsync(int id);
}

}