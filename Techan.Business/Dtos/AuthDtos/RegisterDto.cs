namespace Techan.Business.Dtos.AuthDtos;
public class RegisterDto : IDto
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}