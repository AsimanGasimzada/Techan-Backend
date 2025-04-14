namespace Techan.Business.Dtos.AuthDtos;

public class LoginDto : IDto
{
    public string UsernameOrEmail { get; set; } = null!;
    public string Password { get; set; } = null!;
}