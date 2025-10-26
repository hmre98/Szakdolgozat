using backend.DTOs;
using backend.Models;
using backend.Contracts.Services;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using backend.Enums;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterialController : ControllerBase
{
    private readonly IMaterialService _materialService;

    public MaterialController(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    [HttpGet("GetAllMaterials")]
    public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllMaterialsAsync(int pageNumber, int pageSize, string sortColumn, SortDirection sortDirection)
    {
        var materials = await _materialService.GetAllMaterialsAsync(pageNumber, pageSize, sortColumn, sortDirection);
        return Ok(materials);
    }


    [HttpPost("InsertMaterial")]
    public async Task<IActionResult> InsertMaterialAsync([FromBody] MaterialDTO dto)
    {
        var id = await _materialService.AddMaterialAsync(dto);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MaterialDTO dto)
    {
         var result = await _materialService.UpdateMaterialByIdAsync(id, dto);

         if(result == 0)
         {
             return NotFound();
         }
         return Ok(id);
    }

    [HttpDelete("DeleteMaterial/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _materialService.DeleteMaterialAsync(id);

        if(result == 0)
        {
            return NotFound();
        }
        return Ok(id);
    }
}
