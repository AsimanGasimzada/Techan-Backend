using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Techan.Business.Dtos;
using Techan.Business.Services.Abstractions;

namespace Techan.Presentation.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _service;

    public BrandsController(IBrandService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<ActionResult<ResultDto<List<BrandGetDto>>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles ="Admin")]
    public async Task<ActionResult<ResultDto<BrandGetDto>>> Get(int id)
    {
        var result = await _service.GetAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] BrandCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ResultDto>> Update([FromForm] BrandUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResultDto>> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }

}
