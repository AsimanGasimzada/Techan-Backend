namespace Techan.Business.Dtos;
public class AccessTokenDto : IDto
{
    public string Token { get; set; } = null!;
    public DateTime ExpiredDate { get; set; }

    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpiredAt { get; set; }
}
