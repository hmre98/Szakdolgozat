using backend.DTOs;
using backend.Models;
using backend.Services;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO pagination)
    {

        var allMaterials = await _materialService.GetAllAsQueryableAsync();


        var pagedMaterials = allMaterials.Paginate(pagination).ToList();

        var dtos = pagedMaterials.Select(m => new MaterialDTO
        {
            Id = m.Id,
            Name = m.Name,
            InInventory = m.InInventory
        });

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var material = await _materialService.GetMaterialAsync(id);
        if (material == null) return NotFound();

        var dto = new MaterialDTO
        {
            Id = material.Id,
            Name = material.Name,
            InInventory = material.InInventory
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MaterialDTO dto)
    {
        var material = new Material
        {
            Name = dto.Name,
            InInventory = dto.InInventory
        };

        await _materialService.AddMaterialAsync(material);
        dto.Id = material.Id;

        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MaterialDTO dto)
    {
        if (id != dto.Id) return BadRequest();

        var material = await _materialService.GetMaterialAsync(id);
        if (material == null) return NotFound();

        material.Name = dto.Name;
        material.InInventory = dto.InInventory;

        await _materialService.UpdateMaterialAsync(material);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _materialService.DeleteMaterialAsync(id);
        return NoContent();
    }
}
