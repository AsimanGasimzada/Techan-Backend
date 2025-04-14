using Microsoft.AspNetCore.Mvc;
using Techan.Business.Dtos.AuthDtos;
using Techan.Business.Services.Abstractions;

namespace Techan.Presentation.Controllers;
[Route("/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _service.LoginAsync(dto);

        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult > Register([FromBody]RegisterDto dto)
    {
        var result=await _service.RegisterAsync(dto);

        return Ok(result);
    }
}
