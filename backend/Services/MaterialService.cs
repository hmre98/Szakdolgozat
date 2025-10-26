using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Contracts.Repository;
using backend.DTOs;
using backend.Enums;
using backend.Contracts.Services;

namespace backend.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repository;

        public MaterialService(IMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> UpdateMaterialByIdAsync(int id, MaterialDTO material)
        {

            var _material = await _repository.GetByIdAsync(id);
            _material.Name = material.Name;
            _material.IsSelectable = material.IsSelectable;
            _material.InInventory = material.InInventory;
            await _repository.UpdateAsync(_material);
            return await _repository.SaveChangesAsync();
        }


        public async Task<int> DeleteMaterialAsync(int id)
        {
            var material = await _repository.GetByIdAsync(id);
            if (material == null)
            {
                return 0;
            }

            await _repository.DeleteAsync(id);

            return await _repository.SaveChangesAsync();
        }

        public async Task<Material> GetMaterialByNameAsync(string name)
        {
            var material = await _repository.GetAllAsync();
            return material.Where(x => x.Name == name).FirstOrDefault();
        }

        public async Task<Material> AddMaterialAsync(MaterialDTO newMaterial)
        {
            var material = new Material
            {
                Id = newMaterial.Id,
                Name = newMaterial.Name,
                IsSelectable = newMaterial.IsSelectable,
                InInventory = newMaterial.InInventory
            };

            await _repository.AddAsync(material);
            await _repository.SaveChangesAsync();

            return material;
        }

        public async Task<PagedResult<MaterialDTO>> GetAllMaterialsAsync(int pageNumber, int pageSize, string sortColumn, SortDirection sortDirection)
        {
            var materials = await _repository.GetAllAsync();

            var totalCount= materials.Count();

            var sortedMaterials = sortDirection == SortDirection.Ascending
                ? materials.OrderBy(b => 
                    b.GetType().GetProperty(sortColumn)?.GetValue(b, null) ?? "")
                : materials.OrderByDescending(b => 
                    b.GetType().GetProperty(sortColumn)?.GetValue(b, null) ?? "");

            var pagedMaterials = sortedMaterials.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var materialDTOs = pagedMaterials.Select(b => new MaterialDTO
            {
                Id = b.Id,
                Name = b.Name,
                IsSelectable = b.IsSelectable,
                InInventory = b.InInventory
            });

            return new PagedResult<MaterialDTO>
                {
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    SortColumn = sortColumn,
                    SortDirection = sortDirection,
                    Results = materialDTOs.ToList(),
                };
        }
    }
    
}